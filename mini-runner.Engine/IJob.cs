using System;

namespace mini_runner.Engine
{
    public interface IJob
    {
        bool CanRun();
        void Run(Action<JobState, string> stateChanged);
    }
}