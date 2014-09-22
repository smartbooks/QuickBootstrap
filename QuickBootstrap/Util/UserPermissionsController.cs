using System.Collections.Generic;
using System.Web.Mvc;
using QuickBootstrap.Filters;
using QuickBootstrap.Services;
using QuickBootstrap.Services.Impl;
using QuickBootstrap.Services.Models;

namespace QuickBootstrap.Util
{
    /// <summary>
    /// 抽象用户权限控制器
    /// </summary>
    public abstract class UserPermissionsController : Controller
    {
        protected readonly IUserPermissionsService UserPermissionsService = new UserPermissionsService();

        protected UserPermissionsController()
        {
            var httpCookie = Request.Cookies[UserAuthorizationAttribute.CookieUserName];
            if (httpCookie != null)
            {
                TempData["UserPermissions"] = UserPermissionsService.GetUserRoleMenu(httpCookie.Value);
            }
            else
            {
                TempData["UserPermissions"] = new List<UserRoleMenuItem>();
            }
        }
    }
}