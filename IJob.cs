using System;

namespace JobRunnerWebConsole
{
    public interface IJob
    {
        bool CanRun();
        void Run(Action<JobState, string> stateChanged);
    }
}