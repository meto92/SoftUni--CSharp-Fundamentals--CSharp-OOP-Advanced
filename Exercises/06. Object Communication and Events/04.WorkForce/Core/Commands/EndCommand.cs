using System;

public class EndCommand : ICommand
{
    public void Execute()
    {
        Environment.Exit(0);
    }
}