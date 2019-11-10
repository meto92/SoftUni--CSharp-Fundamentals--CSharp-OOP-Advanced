public class Executor : IExecutor
{
    public void Execute(ICommand command)
    {
        command.Execute();
    }
}