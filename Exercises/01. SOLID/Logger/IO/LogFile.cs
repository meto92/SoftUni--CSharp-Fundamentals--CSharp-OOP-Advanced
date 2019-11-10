using System.IO;
using System.Linq;
using System.Text;

public class LogFile : ILogFile
{
    private const string FilePath = "log.txt";

    private StringBuilder stringBuilder;

    public LogFile()
    {
        this.stringBuilder = new StringBuilder();
    }

    public int Size => this.stringBuilder
        .ToString()
        .Where(c => char.IsLetter(c))
        .Sum(c => (int) c);

    private void Append(string message)
    {
        this.stringBuilder.AppendLine(message);
    }

    public void Log(string message)
    {
        this.Append(message);

        using (FileStream fileStream = new FileStream(FilePath, FileMode.OpenOrCreate))
        {
            byte[] bytes = Encoding.UTF8.GetBytes(this.stringBuilder.ToString());

            fileStream.Write(bytes, 0, bytes.Length);
        }
    }
}