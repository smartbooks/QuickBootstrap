using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuickBootstrap.Models;
using QuickBootstrap.Util;

namespace QuickBootstrap.Controllers
{
    public class TestController : PermissionsController
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Query(TestQueryRequest model)
        {
            var m = model;

            Debug.WriteLine(m.StartTime);
            Debug.WriteLine(m.EndTime);

            return RedirectToAction("Index");
        }
    }
}