public class JobFactory : IJobFactory
{
    public IJob CreateJob(string jobName, int workHoursRequired, IEmployee employee, ISubject jobs, IOutputWriter writer)
    {
        IJob job = new Job(jobName, workHoursRequired, employee, jobs, writer);

        return job;
    }
}