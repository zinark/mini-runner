using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace mini_runner.Engine
{
    public class JobLog
    {
        public DateTime On { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
    }
    public class JobRunnerEngine
    {
        private readonly IEnumerable<Job> _Jobs;
        private readonly IList<JobLog>  _Logs;

        public JobRunnerEngine(IEnumerable<Job> jobs, IList<JobLog> logs)
        {
            _Jobs = jobs;
            _Logs = logs;
        }

        public void Run()
        {
            foreach (var job in _Jobs)
            {
                if (DateTime.Now >= job.NextExecution)
                    if (job.CanRun())
                    {
                        Job job1 = job;
                        var task = new Task(() => job1.Run((s,d)=>executeJob (s,d,job1)));
                        task.Start(TaskScheduler.Current);
                    }
            }
        }

        private void executeJob(JobState state, string details, Job job)
        {
            lock (_Logs)
            {
                _Logs.Add(new JobLog()
                {
                    On = DateTime.Now,
                    Title = "job named '" + job.Name + "' state is " + state,
                    Details = details
                });
            }
        }
    }
}