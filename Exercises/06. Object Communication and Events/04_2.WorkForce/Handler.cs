using System;

public class Handler
{
    public void OnWeekPassed(object sender, WeekPassedEventArgs args)
    {
        foreach (IJob job in args.JobByName.Values)
        {
            job.Update();
        }
    }

    public void OnJobDone(object sender, JobDoneEventArgs args)
    {
        Console.WriteLine($"Job {args.Job.Name} done!");

        args.Jobs.Remove(args.Job);
    }
}