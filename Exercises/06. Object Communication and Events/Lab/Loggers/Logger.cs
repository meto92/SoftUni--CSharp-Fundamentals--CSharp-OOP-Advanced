﻿public abstract class Logger : IHandler
{
    private IHandler successor;

    protected void PassToSuccessor(LogType logType, string message)
    {
        if (this.successor != null)
        {
            this.successor.Handle(logType, message);
        }
    }

    public void SetSuccessor(IHandler successor)
    {
        this.successor = successor;
    }

    public abstract void Handle(LogType logType, string message);
}