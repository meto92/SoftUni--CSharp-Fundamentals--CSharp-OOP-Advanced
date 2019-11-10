public interface ICommandFactory
{
    IExecutable CreateCommand(string[] data, string commandName);
}