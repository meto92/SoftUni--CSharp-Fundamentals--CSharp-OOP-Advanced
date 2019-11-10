using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

public class CommandInterpreter : ICommandInterpreter
{
    public CommandInterpreter(
        IHarvesterController harvesterController, 
        IProviderController providerController)
    {
        this.HarvesterController = harvesterController;
        this.ProviderController = providerController;
    }

    public IHarvesterController HarvesterController { get; }

    public IProviderController ProviderController { get; }

    private ICommand CreateCommand(IList<string> args)
    {
        string type = args[0];

        Type commandType = Assembly.GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name == $"{type}{nameof(Command)}" &&
                typeof(ICommand).IsAssignableFrom(t));

        if (commandType == null)
        {
            throw new ArgumentException(string.Format(Constants.UnknownCommandType, type));
        }

        ConstructorInfo ctor = commandType
            .GetConstructors(BindingFlags.Instance | BindingFlags.Public)
            .First();
        ParameterInfo[] ctorParams = ctor.GetParameters();
        object[] ctorArguments = new object[ctorParams.Length];

        for (int i = 0; i < ctorParams.Length; i++)
        {
            if (ctorParams[i].ParameterType == typeof(IList<string>))
            {
                ctorArguments[i] = args.Skip(1).ToList();
            }
            else
            {
                ctorArguments[i] = this.GetType()
                    .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                    .First(p => p.PropertyType == ctorParams[i].ParameterType)
                    .GetValue(this);
            }
        }

        ICommand command = (ICommand) Activator.CreateInstance(
            commandType,
            ctorArguments);

        return command;
    }

    public string ProcessCommand(IList<string> args)
    {
        ICommand command = this.CreateCommand(args);

        return command.Execute();
    }   
}