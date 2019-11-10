using System;

public class Job : IJob
{
    private string name;
    private int workHoursRequired;
    private IEmployee employee;

    public Job( string name, int workHoursRequired, IEmployee employee)
    {
        this.Name = name;
        this.WorkHoursRequired = workHoursRequired;
        this.Employee = employee;
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

    public bool IsDone => this.WorkHoursRequired <= 0;

    public void Update()
    {
        this.WorkHoursRequired -= this.Employee.WorkHoursPerWeek;

        if (this.WorkHoursRequired <= 0)
        {
            

           //this.subject.Unregister(this);
        }
    }

    public void PrintStatus()
    {
        Console.WriteLine($"Job: {this.Name} Hours Remaining: {this.WorkHoursRequired}");
    }
}