using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using JobRunnerWebConsole;
using mini_runner.Engine;

namespace mini_runner.web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static readonly IList<JobLog> Logs = new List<JobLog>();
        public static readonly IList<Job> Jobs = new List<Job>()
        {
            new FileLoggerJob(),
            new BrokenJob(),
            new DreamJob()
        };
        
        Timer _Timer;

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            _Timer = new Timer(delegate
            {
                new JobRunnerEngine(Jobs, Logs).Run();
            }, null, 0, 1000);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
        }
    }
}