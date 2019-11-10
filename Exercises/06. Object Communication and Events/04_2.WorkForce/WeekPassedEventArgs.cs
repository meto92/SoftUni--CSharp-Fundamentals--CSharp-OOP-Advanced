using System;
using System.Collections.Generic;

public class WeekPassedEventArgs : EventArgs
{
    private Dictionary<string, IJob> jobByName;

    public WeekPassedEventArgs(Dictionary<string, IJob> jobByName)
    {
        this.JobByName = jobByName;
    }

    public Dictionary<string, IJob> JobByName
    {
        get => this.jobByName;
        private set => this.jobByName = value;
    }
}