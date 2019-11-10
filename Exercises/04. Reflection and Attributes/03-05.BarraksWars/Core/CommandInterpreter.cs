using System;
using System.Linq;
using System.Reflection;

public class CommandInterpreter : ICommandInterpreter
{
    private const string CommandSuffix = "Command";
    private const string InvalidCommandMessage = "Invalid command!";

    private IRepository repository;
    private IUnitFactory unitFactory;

    public CommandInterpreter(IRepository repository, IUnitFactory unitFactory)
    {
        this.repository = repository;
        this.unitFactory = unitFactory;
    }

    private void InjectFields(IExecutable command, Type commandType)
    {
        FieldInfo[] fieldsToInject = commandType.GetFields(
            BindingFlags.Instance | BindingFlags.NonPublic)
            .Where(f => f.GetCustomAttributes()
                .Any(a => a.GetType() == typeof(InjectAttribute)))
            .ToArray();

        foreach (FieldInfo field in fieldsToInject)
        {
            field.SetValue(command, 
                typeof(CommandInterpreter)
                    .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                    .First(f => f.FieldType == field.FieldType)
                    .GetValue(this));
        }
    }

    public IExecutable InterpretCommand(string[] data, string commandName)
    {
        Type commandType = Assembly.GetExecutingAssembly()
            .GetTypes()
            .First(t => t.IsClass
                && t.Name.Equals($"{commandName}{CommandSuffix}",
                    StringComparison.OrdinalIgnoreCase));

        IExecutable command = Activator.CreateInstance(commandType, new object[] { data }) as IExecutable;

        if (command == null)
        {
            throw new NotSupportedException(InvalidCommandMessage);
        }

        InjectFields(command, commandType);
        
        return command;
    }
}