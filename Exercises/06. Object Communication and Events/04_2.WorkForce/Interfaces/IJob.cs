public interface IJob
{
    string Name { get; }

    IEmployee Employee { get; }

    int WorkHoursRequired { get; }

    bool IsDone { get; }

    void PrintStatus();

    void Update();
}