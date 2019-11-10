public interface IJob
{
    string Name { get; }

    int WorkHoursRequired { get; }

    IEmployee Employee { get; }

    void PrintInfo();
}