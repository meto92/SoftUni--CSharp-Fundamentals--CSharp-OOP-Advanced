using System;

public class CommandNotFoundExeption : Exception
{
    private const string CommandNotFound = "Command '{0}' does not exist.";

    public CommandNotFoundExeption()
        : base()
    { }

    public CommandNotFoundExeption(string command)
        : base(string.Format(CommandNotFound, command))
    { }
}