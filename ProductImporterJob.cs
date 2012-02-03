using System;
using System.Threading;

namespace JobRunnerWebConsole
{
    public class ProductImporterJob : Job
    {
        public ProductImporterJob()
            : base("Product Importer Job", new TimeSpan(0, 0, 0, 30))
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