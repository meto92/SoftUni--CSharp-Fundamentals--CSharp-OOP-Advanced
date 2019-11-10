public class Startup
{
    public static void Main()
    {
        new Engine(new ConsoleReader(), new ConsoleWriter())
            .Run();
    }
}