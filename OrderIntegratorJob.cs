using System;
using System.Threading;

namespace JobRunnerWebConsole
{
    public class OrderIntegratorJob : Job
    {
        public OrderIntegratorJob() : base("Order Integrator Job", new TimeSpan(0,0,0,15))
        {

        }

        public override bool CanRun()
        {
            return true;
        }

        public override void OnRun()
        {
            Thread.Sleep(5000);
            throw new Exception("unknown error");
        }
    }
}