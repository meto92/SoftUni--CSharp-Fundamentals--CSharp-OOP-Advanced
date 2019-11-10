using System.Collections.Generic;

public interface ILogger
{
    IList<IAppender> Appenders { get; }

    void AddAppenders(IEnumerable<IAppender> newAppenders);

    void Info(string dateAndTime, string message);

    void Warn(string dateAndTime, string message);

    void Error(string dateAndTime, string message);

    void Critical(string dateAndTime, string message);

    void Fatal(string dateAndTime, string message);
}