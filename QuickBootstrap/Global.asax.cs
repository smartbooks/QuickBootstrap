using System;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using log4net;
using QuickBootstrap.Cache;
using QuickBootstrap.Entities;
using StackExchange.Redis;

namespace QuickBootstrap
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private readonly static string RedisConnection = ConfigurationManager.AppSettings["RedisConnection"];
        private readonly ILog _logger = LogManager.GetLogger(typeof(MvcApplication));

        protected void Application_Start()
        {
            AppDomain.CurrentDomain.FirstChanceException += CurrentDomainOnFirstChanceException;

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Task.Factory.StartNew(() =>
            {
                Database.SetInitializer(new CreateDatabaseIfNotExists<DefaultDbContext>());
                Database.SetInitializer(new InitData());
                var count = new DefaultDbContext().User.Count();

                if (RedisContext.RedisDatabase == null)
                {
                    RedisContext.RedisDatabase = ConnectionMultiplexer.Connect(RedisConnection).GetDatabase();
                }
            });
        }

        private void CurrentDomainOnFirstChanceException(object sender, FirstChanceExceptionEventArgs e)
        {
            _logger.Error(e.Exception);
        }

        protected void Application_Error(Object sender, EventArgs e)
        {
            var lastError = Server.GetLastError().GetBaseException();
            {
                _logger.Error(lastError);
            }
        }
    }
}
