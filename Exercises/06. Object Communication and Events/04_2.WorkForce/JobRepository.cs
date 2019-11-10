using static Startup;
using System.Collections.Generic;

public class JobRepository
{
    private event WeekPassedEventHandler WeekPassed;
    private event JobDoneEventHandler JobDone;

    private Handler handler;
    private List<IJob> jobs;

    public JobRepository(Handler handler)
    {
        this.handler = handler;
        this.jobs = new List<IJob>();
        this.WeekPassed = handler.OnWeekPassed;
        this.JobDone = handler.OnJobDone;
    }

    public void AddJob(IJob job)
    {
        this.jobs.Add(job);
    }

    public void PassWeek()
    {
        for (int i = 0; i < this.jobs.Count; i++)
        {
            this.jobs[i].Update();

            if (this.jobs[i].IsDone)
            {
                this.JobDone(this, new JobDoneEventArgs(this.jobs[i], this.jobs));

                i--;
            }
        }
    }

    public void PrintJobsStatus()
    {
        this.jobs.ForEach(job => job.PrintStatus());
    }
}