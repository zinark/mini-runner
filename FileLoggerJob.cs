using System;
using System.IO;
using System.Threading;
using mini_runner.Engine;

namespace JobRunnerWebConsole
{
    public class FileLoggerJob : Job
    {
        public FileLoggerJob() : base("File Logger Job", new TimeSpan(0,0,0,15))
        {

        }

        public override bool CanRun()
        {
            return true;
        }

        public override void OnRun()
        {
            var desktop = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "fileloggerjob.txt");
            File.AppendAllText(desktop,"FileLoggerJob writing " + DateTime.Now + Environment.NewLine);
        }
    }
}