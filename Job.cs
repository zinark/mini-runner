using System;
using System.Threading;

namespace JobRunnerWebConsole
{
    public abstract class Job : IJob
    {
        private string _Name;
        public string Name
        {
            get { return _Name; }
        }

        private TimeSpan _Period;
        public TimeSpan Period
        {
            get { return _Period; }
        }

        private JobState _State;
        public JobState State
        {
            get { return _State; }
        }

        private DateTime _NextExecution;
        
        public DateTime NextExecution
        {
            get { return _NextExecution; }
        }

        public Job(string name, TimeSpan period)
        {
            _Name = name;
            _Period = period;
            _State = JobState.Waiting;
            _NextExecution = DateTime.Now.Add(TimeSpan.FromSeconds(5));
        }

        public abstract bool CanRun();
        
        public void Run(Action<JobState, string> stateChanged)
        {
            if (_State == JobState.Running) return;
            try
            {
                ChangeState(JobState.Running, "", stateChanged);
                CalculateNextExecution();

                OnRun();

                ChangeState(JobState.Done, "", stateChanged);
                Thread.Sleep(5000);
                

                ChangeState(JobState.Waiting, "", stateChanged);
            }
            catch (Exception ex)
            {
                ChangeState(JobState.Error, ex.Message, stateChanged);
                Thread.Sleep(5000);
                CalculateNextExecution();
                // throw;
            }
        }

        private void CalculateNextExecution()
        {
            _NextExecution = DateTime.Now.Add(_Period);
        }

        private void ChangeState(JobState state, string details, Action<JobState, string> stateChanged)
        {
            _State = state;
            stateChanged(state, details);
        }

        public abstract void OnRun();
    }
}