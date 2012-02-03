using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI;

namespace JobRunnerWebConsole
{
    public partial class Default : Page
    {
        public IEnumerable<Job> Jobs
        {
            get { return Global.Jobs.AsEnumerable(); }
        }

        public IEnumerable<string> Logs
        {
            get
            {
                return Global.Logs
                    .OrderByDescending(x => x.On)
                    .Take(45)
                    .Select(x => "[" + x.On + "]" + x.Title + " " + x.Details);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}