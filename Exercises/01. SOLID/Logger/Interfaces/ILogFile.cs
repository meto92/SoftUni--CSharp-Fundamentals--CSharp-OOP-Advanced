public interface ILogFile
{
    int Size { get; }

    void Log(string message);
}