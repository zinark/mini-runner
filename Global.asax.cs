using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Web;

namespace JobRunnerWebConsole
{
    public class Global : HttpApplication
    {
        public static readonly IList<JobLog> Logs = new List<JobLog>();
        public static readonly IList<Job> Jobs = new List<Job>()
        {
            new OrderIntegratorJob(),
            new ProductImporterJob(),
            new ProductStateJob()
        };
        private Timer _Timer;

        protected void Application_Start(object sender, EventArgs e)
        {
            _Timer = new Timer(delegate
            {
                new JobRunnerEngine(Jobs, Logs).Run();
            }, null, 0, 1000);
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {
            _Timer.Dispose();
        }
    }
}