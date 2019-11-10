using System.Text;

public class XmlLayout : ILayout
{
    private const string Indent = "\t";

    public string FormatLogData(string dateAndTime, string message, ReportLevel reportLevel)
    {
        StringBuilder result = new StringBuilder();

        result.AppendLine("<log>");
        result.AppendLine($"{Indent}<date>{dateAndTime}</date>");
        result.AppendLine($"{Indent}<level>{reportLevel.ToString().ToUpper()}</level>");
        result.AppendLine($"{Indent}<message>{message}</message>");
        result.Append("</log>");

        return result.ToString();
    }
}