public class Startup
{
    public static void Main()
    {
        ILogger logger = new Logger();
        IInputReader inputReader = new ConsoleReader();
        IOutputWriter outputWriter = new ConsoleWriter();

        new Engine(logger, inputReader, outputWriter).Run();
    }
}