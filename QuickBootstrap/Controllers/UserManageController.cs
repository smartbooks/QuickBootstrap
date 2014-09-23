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
        private readonly IDepartmentService _departmentService = new DepartmentService();
        private readonly IRoleService _roleService = new RoleService();

        #endregion

        #region action method

        public ActionResult Index(int pageIndex = 0, int pageSize = 20)
        {
            var paging = new Paging { PageIndex = pageIndex, PageSize = pageSize };
            return View(_userManageService.GetList(paging));
        }

        public ActionResult Create()
        {
            BindSelectListDataSource();

            var viewModel = new UserCreateRequest();

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(UserCreateRequest model)
        {
            if (ModelState.IsValid == false)
            {
                BindSelectListDataSource();

                return View(model);
            }

            var userPwdHash = model.Password.ToMd5();

            if (!_userManageService.ExistsUser(model.UserName))
            {
                _userManageService.Create(new User
                {
                    UserName = model.UserName,
                    UserPwd = userPwdHash,
                    Nick = model.Nick,
                    CreateTime = DateTime.Now
                });

                return RedirectToAction("Index");
            }

            ModelState.AddModelError("_error", "登录账号已存在");

            return View();
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

        #region 私有方法

        private void BindSelectListDataSource()
        {
            ViewBag.RoleList = new SelectList(_roleService.GetAllList(), "ID", "Title");
            ViewBag.DepartmentList = new SelectList(_departmentService.GetAllList(), "ID", "Title");
        }

        #endregion
    }
}