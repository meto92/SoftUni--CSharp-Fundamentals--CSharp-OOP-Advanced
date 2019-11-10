using System;

public class EventLogger : Logger
{
    public override void Handle(LogType logType, string message)
    {
        switch (logType)
        {
            case LogType.ATTACK:
            case LogType.MAGIC:
                Console.WriteLine($"{logType}: {message}");
                break;
            //case LogType.TARGET:
            //    break;
            //case LogType.ERROR:
            //    break;
            //case LogType.EVENT:
            //    break;
        }

        base.PassToSuccessor(logType, message);
    }
}