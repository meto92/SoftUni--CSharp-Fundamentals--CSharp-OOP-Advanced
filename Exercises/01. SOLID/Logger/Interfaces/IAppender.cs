public interface IAppender
{
    ReportLevel ReportLevel { get; set; }

    ILayout Layout { get; }

    int ReportedLogsCount { get; }

    void Append(string dateAndTime, string message, ReportLevel reportLevel);
}