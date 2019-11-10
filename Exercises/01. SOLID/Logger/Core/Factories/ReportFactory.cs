using System;

public class ReportFactory
{
    public Report CreateReport(string reportType, string dateAndTime, string message)
    {
        ReportLevel reportLevel = Enum.Parse<ReportLevel>(reportType, true);

        Report report = new Report(reportLevel, dateAndTime, message);

        return report;
    }
}