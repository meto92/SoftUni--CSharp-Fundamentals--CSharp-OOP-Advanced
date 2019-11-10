public interface ILayout
{
    string FormatLogData(string dateAndTime, string message, ReportLevel reportLevel);
}