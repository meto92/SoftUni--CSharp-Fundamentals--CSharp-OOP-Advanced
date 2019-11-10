public class SimpleLayout : ILayout
{
    public string FormatLogData(string dateAndTime, string message, ReportLevel reportLevel)
    {
        string result = $"{dateAndTime} - {reportLevel.ToString().ToUpper()} - {message}";

        return result;
    }
}