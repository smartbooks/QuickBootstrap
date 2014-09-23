using System;
using System.Web.Mvc;
using QuickBootstrap.Entities;
using QuickBootstrap.Filters;
using QuickBootstrap.Models;
using QuickBootstrap.Services;
using QuickBootstrap.Services.Impl;
using QuickBootstrap.Services.Util;

namespace QuickBootstrap.Controllers
{
    [UserAuthorization]
    public class DepartmentManageController : Controller
    {
        private readonly IDepartmentService _departmentService = new DepartmentService();

        public ActionResult Index(int pageIndex = 0, int pageSize = 20)
        {
            var paging = new Paging { PageIndex = pageIndex, PageSize = pageSize };

            var queryPageResult = _departmentService.GetList(paging);

            return View(queryPageResult);
        }

        public ActionResult Create()
        {
            return View(new DepartmentManageCreateRequest { IsEnable = true, Order = 100 });
        }

        [HttpPost]
        [ValidateModelState]
        public ActionResult Create(DepartmentManageCreateRequest model)
        {
            _departmentService.Create(new Department
            {
                CreateTime = DateTime.Now,
                IsEnable = model.IsEnable,
                Order = model.Order,
                Title = model.Title
            });

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id = 0)
        {
            if (id <= 0)
            {
                return RedirectToAction("Index");
            }

            var dbModel = _departmentService.Get(id);

            var viewModel = new DepartmentManageEditRequest
            {
                Id = dbModel.Id,
                IsEnable = dbModel.IsEnable,
                Order = dbModel.Order,
                Title = dbModel.Title
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateModelState]
        public ActionResult Edit(DepartmentManageEditRequest model)
        {
            _departmentService.Edit(new Department
            {
                IsEnable = model.IsEnable,
                Id = model.Id,
                Order = model.Order,
                Title = model.Title
            });

            return RedirectToAction("Index");
        }
    }
}