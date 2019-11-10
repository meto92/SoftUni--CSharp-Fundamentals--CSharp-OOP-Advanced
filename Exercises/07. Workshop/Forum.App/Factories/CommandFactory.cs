namespace Forum.App.Factories
{
	using Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandFactory : ICommandFactory
	{
        private const string CommandSuffix = "Command";
        private const string CommandNotFoundMessage = "Command {0} not found!";

        private IServiceProvider serviceProvider;

        public CommandFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public ICommand CreateCommand(string commandName)
		{
            Type commandType = Assembly.GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == $"{commandName}{CommandSuffix}");

            if (commandType == null)
            {
                throw new InvalidOperationException(
                    string.Format(CommandNotFoundMessage, $"{commandName}Command"));
            }

            if (!typeof(ICommand).IsAssignableFrom(commandType))
            {
                throw new InvalidOperationException($"{commandType} is not a command!");
            }

            ParameterInfo[] ctorParams = commandType.GetConstructors().First().GetParameters();
            object[] args = new object[ctorParams.Length];

            for (int i = 0; i < args.Length; i++)
            {
                args[i] = this.serviceProvider.GetService(ctorParams[i].ParameterType);
            }

            ICommand command = (ICommand) Activator.CreateInstance(commandType, args);
            
            return command;
		}
	}
}