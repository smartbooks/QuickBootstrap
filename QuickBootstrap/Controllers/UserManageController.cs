using System;
using System.Web.Mvc;
using QuickBootstrap.Entities;
using QuickBootstrap.Extendsions;
using QuickBootstrap.Filters;
using QuickBootstrap.Models;
using QuickBootstrap.Services;
using QuickBootstrap.Services.Impl;
using QuickBootstrap.Services.Util;

namespace QuickBootstrap.Controllers
{
    [UserAuthorization]
    public class UserManageController : Controller
    {
        #region 私有字段

        private readonly IUserManageService _userManageService = new UserManageService();

        #endregion

        #region action method

        public ActionResult Index(int pageIndex = 0, int pageSize = 20)
        {
            var paging = new Paging { PageIndex = pageIndex, PageSize = pageSize };
            return View(_userManageService.GetList(paging));
        }

        public ActionResult Create()
        {
            var viewModel = new UserCreateRequest {IsEnable = true};

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(UserCreateRequest model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            if (_userManageService.ExistsUser(model.UserName) == false)
            {
                _userManageService.Create(new User
                {
                    UserName = model.UserName,
                    UserPwd = model.Password.ToMd5(),
                    Nick = model.Nick,
                    CreateTime = DateTime.Now,
                    IsEnable = model.IsEnable
                });

                return RedirectToAction("Index");
            }

            ModelState.AddModelError("_error", "登录账号已存在");

            return View(model);
        }

        public ActionResult Delete(string username = "")
        {
            if (username.Length > 0)
            {
                _userManageService.Delete(username);
            }

            return RedirectToAction("Index");
        }

        #endregion
    }
}