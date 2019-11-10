using System.Collections.Generic;

public class Logger : ILogger
{
    private List<IAppender> appenders;

    public Logger(params IAppender[] appenders)
    {
        this.appenders = new List<IAppender>(appenders);
    }

    public IList<IAppender> Appenders => this.appenders;

    public void AddAppenders(IEnumerable<IAppender> newAppenders)
    {
        this.appenders.AddRange(newAppenders);
    }

    private void Report(string dateAndTime, string message, ReportLevel reportLevel)
    {
        this.appenders
            .ForEach(appender => appender.Append(
                dateAndTime,
                message,
                reportLevel));
    }

    public void Info(string dateAndTime, string message)
    {
        this.Report(dateAndTime, message, ReportLevel.Info);
    }

    public void Warn(string dateAndTime, string message)
    {
        this.Report(dateAndTime, message, ReportLevel.Warning);
    }

    public void Error(string dateAndTime, string message)
    {
        this.Report(dateAndTime, message, ReportLevel.Error);
    }

    public void Critical(string dateAndTime, string message)
    {
        this.Report(dateAndTime, message, ReportLevel.Critical);
    }

    public void Fatal(string dateAndTime, string message)
    {
        this.Report(dateAndTime, message, ReportLevel.Fatal);
    }
}