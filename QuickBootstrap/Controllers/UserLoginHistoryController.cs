using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuickBootstrap.Filters;
using QuickBootstrap.Services;
using QuickBootstrap.Services.Impl;
using QuickBootstrap.Services.Util;

namespace QuickBootstrap.Controllers
{
    [UserAuthorization]
    public class UserLoginHistoryController : Controller
    {
        private readonly IUserLoginHistoryService _userLoginHistoryService = new UserLoginHistoryService();

        // GET: UserLoginHistory
        public ActionResult Index(int pageIndex = 0, int pageSize = 20)
        {
            var paging = new Paging { PageIndex = pageIndex, PageSize = pageSize };

            var queryPageResult = _userLoginHistoryService.GetList(paging);

            return View(queryPageResult);
        }
    }
}