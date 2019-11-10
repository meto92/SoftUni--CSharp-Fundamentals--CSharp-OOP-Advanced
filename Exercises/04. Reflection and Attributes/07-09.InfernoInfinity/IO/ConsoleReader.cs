public class ConsoleReader : IInputReader
{
    public string ReadLine() => System.Console.ReadLine();
}