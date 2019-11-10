using System;

public class ConsoleAppender : Appender
{
    public ConsoleAppender(ILayout layout)
        : base(layout)
    { }

    protected override bool TryAppend(string dateAndTime, string message, ReportLevel reportLevel)
    {
        if (base.IsReportedLevelHighEnoughToLog(reportLevel))
        {
            string formattedData = base.Layout.FormatLogData(
                dateAndTime,
                message,
                reportLevel);

            Console.WriteLine(formattedData);

            return true;
        }

        return false;
    }
}