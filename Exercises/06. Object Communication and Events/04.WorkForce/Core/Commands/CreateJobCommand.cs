public class CreateJobCommand : ICommand
{
    [Inject]
    private IEmployeeRepository employeeRepository;
    [Inject]
    private ISubject jobs;
    [Inject]
    private IOutputWriter writer;
    [Inject]
    private IJobFactory jobFactory;
    private string jobName;
    private int workHoursRequired;
    private IEmployee employee;

    public CreateJobCommand(
        string jobName, 
        int workHoursRequired, 
        IEmployee employee)
    {
        this.jobName = jobName;
        this.workHoursRequired = workHoursRequired;
        this.employee = employee;
    }

    public void Execute()
    {
        IObservableJob job = this.jobFactory.CreateJob(this.jobName, this.workHoursRequired, this.employee, this.jobs, writer) as IObservableJob;

        this.jobs.Register(job);
    }
}