using System.Web.Mvc;
using QuickBootstrap.Services;
using QuickBootstrap.Services.Impl;

namespace QuickBootstrap.Filters
{
    public class UserAuthorizationAttribute : ActionFilterAttribute
    {
        public static readonly string CookieUserName = "username";
        public static readonly string ManageLoginUrl = "/home/login";

        private readonly IUserPermissionsService _userPermissionsService = new UserPermissionsService();

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //简单验证cookie中username是否为空
            if (filterContext.HttpContext.Request.Cookies[CookieUserName] == null ||
                string.IsNullOrWhiteSpace(filterContext.HttpContext.Request.Cookies[CookieUserName].Value))
            {
                filterContext.Result = new RedirectResult(ManageLoginUrl);
            }
            else
            {
                var username = filterContext.HttpContext.Request.Cookies[CookieUserName].Value;
                filterContext.Controller.TempData["UserPermissions"] = _userPermissionsService.GetUserRoleMenu(username);
            }

            //复杂验证逻辑

            base.OnActionExecuting(filterContext);
        }
    }
}