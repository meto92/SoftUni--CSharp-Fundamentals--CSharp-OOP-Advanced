public class Engine : IRunnable
{
    private ISubject subject;
    private ICommandParser commandParser;
    private IExecutor commandExecutor;
    private IInputReader reader;

    public Engine(
        ISubject subject, 
        ICommandParser commandParser, 
        IExecutor commandExecutor, 
        IInputReader reader)
    {
        this.subject = subject;
        this.commandParser = commandParser;
        this.commandExecutor = commandExecutor;
        this.reader = reader;
    }

    public void Run()
    {
        while (true)
        {
            string input = this.reader.ReadLine();

            ICommand command = commandParser.ParseCommand(input);

            commandExecutor.Execute(command);
        }
    }
}