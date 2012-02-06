using System;
using System.Threading;
using mini_runner.Engine;

namespace JobRunnerWebConsole
{
    public class BrokenJob : Job
    {
        public BrokenJob()
            : base("Broken Job", new TimeSpan(0, 0, 0, 30))
        {

        }

        public override bool CanRun()
        {
            return true;
        }

        public override void OnRun()
        {
            Thread.Sleep(10000);
            throw new Exception(("Hello world"));
        }
    }
}