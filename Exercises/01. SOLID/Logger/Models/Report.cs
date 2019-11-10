public class Report
{
    private ReportLevel reportLevel;
    private string dateAndTime;
    private string message;

    public Report(ReportLevel reportLevel, string dateAndTime, string message)
    {
        this.ReportLevel = reportLevel;
        this.DateAndTime = dateAndTime;
        this.Message = message;
    }

    public ReportLevel ReportLevel
    {
        get => this.reportLevel;
        private set => this.reportLevel = value;
    }

    public string DateAndTime
    {
        get => this.dateAndTime;
        private set => this.dateAndTime = value;
    }

    public string Message
    {
        get => this.message;
        private set => this.message = value;
    }
}