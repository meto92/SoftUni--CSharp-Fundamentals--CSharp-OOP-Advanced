public class Job : IObservableJob
{
    private string name;
    private int workHoursRequired;
    private IEmployee employee;
    private ISubject subject;
    private IOutputWriter writer;

    public Job(
        string name, 
        int workHoursRequired, 
        IEmployee employee, 
        ISubject subject, 
        IOutputWriter writer)
    {
        this.Name = name;
        this.WorkHoursRequired = workHoursRequired;
        this.Employee = employee;
        this.subject = subject;
        this.writer = writer;
    }

    public string Name
    {
        get => this.name;
        private set => this.name = value;
    }

    public int WorkHoursRequired
    {
        get => this.workHoursRequired;
        private set => this.workHoursRequired = value;
    }

    public IEmployee Employee
    {
        get => this.employee;
        private set => this.employee = value;
    }
    
    public void Update()
    {
        this.WorkHoursRequired -= this.Employee.WorkHoursPerWeek;

        if (this.WorkHoursRequired <= 0)
        {
            writer.WriteLine($"Job {this.Name} done!");

           this.subject.Unregister(this);
        }
    }

    public void PrintInfo()
    {
        this.writer.WriteLine($"Job: {this.Name} Hours Remaining: {this.WorkHoursRequired}");
    }
}