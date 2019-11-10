using System;
using System.Linq;
using System.Reflection;

public class CommandFactory : ICommandFactory
{
    private const string CommandSuffix = "Command";
    private const string UnknownCommandNameMessage = "Unknown command name: {0}";

    public IExecutable CreateCommand(string[] data, string commandName)
    {
        Type commandType = Assembly.GetExecutingAssembly()
        .GetTypes()
        .FirstOrDefault(t => t.GetCustomAttributes()
            .Any(a => a.GetType() == typeof(CommandAttribute))
            && t.Name.Equals($"{commandName}{CommandSuffix}",
                StringComparison.OrdinalIgnoreCase));

        if (commandType == null)
        {
            throw new NotSupportedException(
                string.Format(UnknownCommandNameMessage, commandName));
        }

        IExecutable command = Activator
            .CreateInstance(commandType, new object[] { data }) as IExecutable;

        return command;
    }
}