using System;
using System.Threading;
using mini_runner.Engine;

namespace JobRunnerWebConsole
{
    public class DreamJob : Job
    {
        public DreamJob()
            : base("Dream Job", new TimeSpan(0, 0, 0, 45))
        {

        }

        public override bool CanRun()
        {
            return true;
        }

        public override void OnRun()
        {
            Thread.Sleep(5000);
        }
    }
}