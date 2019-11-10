using System.Linq;
using System.Reflection;

public class CommandInterpreter : ICommandInterpreter
{
    private IWeaponRepository weaponRepository;
    private ICommandFactory commandFactory;
    private IWeaponFactory weaponFactory;
    private IGemFactory gemFactory;
    private IOutputWriter outputWriter;

    public CommandInterpreter(
        IWeaponRepository weaponRepository,
        ICommandFactory commandFactory,
        IWeaponFactory weaponFactory, 
        IGemFactory gemFactory,
        IOutputWriter outputWriter)
    {
        this.weaponRepository = weaponRepository;
        this.commandFactory = commandFactory;
        this.weaponFactory = weaponFactory;
        this.gemFactory = gemFactory;
        this.outputWriter = outputWriter;
    }

    private void InjectFields(IExecutable command)
    {
        FieldInfo[] fieldsToInject = command.GetType().GetFields(
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
        IExecutable command = this.commandFactory.CreateCommand(data, commandName);

        InjectFields(command);

        return command;
    }
}