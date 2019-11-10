public abstract class Employee : IEmployee
{
    private string name;
    private int workHoursPerWeek;

    protected Employee(string name, int workHoursPerWeek)
    {
        this.Name = name;
        this.WorkHoursPerWeek = workHoursPerWeek;
    }

    public string Name
    {
        get => this.name;
        private set => this.name = value;
    }

    public int WorkHoursPerWeek
    {
        get => this.workHoursPerWeek;
        private set => this.workHoursPerWeek = value;
    }
}