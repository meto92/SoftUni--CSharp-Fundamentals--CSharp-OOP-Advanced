public abstract class Appender : IAppender
{
    private const string AppenderInfoFormat = "Appender type: {0}, Layout type: {1}, Report level: {2}, Messages appended: {3}";

    private ILayout layout;
    private ReportLevel reportLevel;
    private int reportedLogsCount;

    protected Appender(ILayout layout)
    {
        this.Layout = layout;
        this.ReportLevel = ReportLevel.Info;
        this.ReportedLogsCount = 0;
    }

    public ILayout Layout
    {
        get => this.layout;
        set => this.layout = value;
    }

    public ReportLevel ReportLevel
    {
        get => this.reportLevel;
        set => this.reportLevel = value;
    }

    public int ReportedLogsCount
    {
        get => this.reportedLogsCount;
        private set => this.reportedLogsCount = value;
    }

    protected bool IsReportedLevelHighEnoughToLog(ReportLevel reportLevel)
    {
        return reportLevel >= this.ReportLevel;
    }

    protected abstract bool TryAppend(string dateAndTime, string message, ReportLevel reportLevel);

    public void Append(string dateAndTime, string message, ReportLevel reportLevel)
    {
        if (this.TryAppend(dateAndTime, message, reportLevel))
        {
            this.ReportedLogsCount++;
        }
    }

    public override string ToString()
    {
        string result = string.Format(AppenderInfoFormat,
            this.GetType().Name,
            this.Layout.GetType().Name,
            this.ReportLevel.ToString().ToUpper(),
            this.ReportedLogsCount);
        
        FileAppender fileAppender = this as FileAppender;

        if (fileAppender != null)
        {
             result = string.Concat(result, $", File size: {fileAppender.File.Size}");
        }

        return result;
    }
}