public class PassWeekCommand : ICommand
{
    [Inject]
    private ISubject jobs;

    public void Execute()
    {
        this.jobs.NotifyObservers();
    }
}