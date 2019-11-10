public class FileAppender : Appender
{
    private LogFile file;

    public FileAppender(ILayout layout)
        : base(layout)
    {
        this.File = new LogFile();
    }

    public LogFile File
    {
        get => this.file;
        set => this.file = value;
    }

    protected override bool TryAppend(string dateAndTime, string message, ReportLevel reportLevel)
    {
        if (base.IsReportedLevelHighEnoughToLog(reportLevel))
        {
            string formattedData = base.Layout.FormatLogData(
                dateAndTime,
                message,
                reportLevel);

            this.File.Log(formattedData);

            return true;
        }

        return false;
    }
}