using System.Collections.Generic;
using System.Linq;
using JobRunnerWebConsole;
using mini_runner.Engine;

namespace mini_runner.web.Models
{
    public class HomeViewModel
    {
        public IEnumerable<Job> Jobs
        {
            get { return MvcApplication.Jobs.AsEnumerable(); }
        }

        public IEnumerable<string> Logs
        {
            get
            {
                return MvcApplication.Logs
                    .OrderByDescending(x => x.On)
                    .Take(45)
                    .Select(x => "[" + x.On + "]" + x.Title + " " + x.Details);
            }
        }

    }
}