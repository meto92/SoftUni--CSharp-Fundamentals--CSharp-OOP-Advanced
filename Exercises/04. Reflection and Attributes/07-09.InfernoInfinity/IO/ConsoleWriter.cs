public class ConsoleWriter : IOutputWriter
{
    public void WriteLine(string message) => System.Console.WriteLine(message);
}