using System;
using System.Collections.Generic;

public class JobDoneEventArgs : EventArgs
{
    private IJob job;

    public JobDoneEventArgs(IJob job, List<IJob> jobs)
    {
        this.Job = job;
        this.jobs = jobs;
    }
    private List<IJob> jobs;

    public IJob Job
    {
        get => this.job;
        private set => this.job = value;
    }

    public IList<IJob> Jobs => this.jobs;
}