using System.Web;
using System.Web.Mvc;
using QuickBootstrap.Extendsions;
using QuickBootstrap.Filters;
using QuickBootstrap.Models;
using QuickBootstrap.Services;
using QuickBootstrap.Services.Impl;

namespace QuickBootstrap.Controllers
{
    public class HomeController : Controller
    {
        #region 私有字段

        private readonly IManageService _manageService = new ManageService();

        #endregion

        #region index method

        [UserAuthorization]
        public ActionResult Index()
        {
            return View();
        }

        #endregion

        #region 登录操作

        public ActionResult Login()
        {
            return View(new HomeLoginRequest());
        }

        [HttpPost]
        [ValidateModelState]
        public ActionResult Login(HomeLoginRequest model)
        {
            model.Trim();

            var loginUserSession = _manageService.GetUserSession(model.UserName, model.Password.ToMd5(), Request.UserHostAddress);

            if (loginUserSession != null)
            {
                Session[Session.SessionID] = loginUserSession;

                var userCookie = new HttpCookie(UserAuthorizationAttribute.CookieUserName, model.UserName);

                Response.Cookies.Add(userCookie);

                return RedirectToAction("Index");
            }

            ModelState.AddModelError("_error", "登录密码错误或用户不存在或用户被禁用。");

            return View();
        }

        #endregion

        #region 注销操作

        [UserAuthorization]
        public ActionResult LoginOut()
        {
            if (Request.Cookies[UserAuthorizationAttribute.CookieUserName] != null &&
                !string.IsNullOrWhiteSpace(Request.Cookies[UserAuthorizationAttribute.CookieUserName].Value))
            {
                //退出登录日志记录操作
                _manageService.LoginOut(Request.Cookies[UserAuthorizationAttribute.CookieUserName].Value, Request.UserHostAddress);

                Session[Session.SessionID] = null;

                Response.Cookies.Add(new HttpCookie(UserAuthorizationAttribute.CookieUserName, string.Empty));
            }

            return RedirectToAction("Login");
        }

        #endregion
    }
}