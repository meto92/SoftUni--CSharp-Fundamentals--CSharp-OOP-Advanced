using System;

public class ConsoleReader : IInputReader
{
    public string ReadLine() => Console.ReadLine();
}