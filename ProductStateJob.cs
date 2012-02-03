using System;
using System.Threading;

namespace JobRunnerWebConsole
{
    public class ProductStateJob : Job
    {
        public ProductStateJob()
            : base("Product State Job", new TimeSpan(0, 0, 0, 45))
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