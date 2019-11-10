public interface IJobFactory
{
    IJob CreateJob(string jobName, int workHoursRequired, IEmployee employee, ISubject jobs, IOutputWriter writer);
}