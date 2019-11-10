public class Startup
{
    public static void Main()
    {
        ISubject subject = new Jobs();
        IInputReader reader = new ConsoleReader();
        IOutputWriter writer = new ConsoleWriter();
        IEmployeeRepository employeeRepository = new EmployeeRepository();
        IEmployeeFactory employeeFactory = new EmployeeFactory();
        IJobFactory jobFactory = new JobFactory();
        IExecutor commandExecutor = new Executor();
        ICommandParser commandParser = new CommandParser(
            subject, 
            employeeRepository, 
            employeeFactory,
            jobFactory,
            writer);

        IRunnable engine = new Engine(subject, commandParser, commandExecutor, reader);

        engine.Run();        
    }
}