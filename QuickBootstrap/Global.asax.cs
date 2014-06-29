using System;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using log4net;
using QuickBootstrap.Entities;

namespace QuickBootstrap
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AppDomain.CurrentDomain.FirstChanceException += (sender, args) =>
            {
                var log = LogManager.GetLogger(typeof(MvcApplication));
                log.Error(args);
            };

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            InitDataBase();
        }

        protected void Application_Error(Object sender, EventArgs e)
        {
            var lastError = Server.GetLastError().GetBaseException();
            {
                var log = LogManager.GetLogger(typeof(MvcApplication));
                log.Error(lastError);
            }
        }

        private static void InitDataBase()
        {
            //数据库不存在时创建
            Database.SetInitializer(new CreateDatabaseIfNotExists<DefaultDbContext>());

            //初始化数据
            Database.SetInitializer(new InitData());

            var log = LogManager.GetLogger(typeof(MvcApplication));
            log.Info(string.Format("{0}-start", DateTime.Now));
        }
    }
}
