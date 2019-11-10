using System;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

using BashSoft.Contracts;
using BashSoft.Attributes;

namespace BashSoft.IO
{
    public class CommandInterpreter : IInterpreter
    {
        private IContentComparer judge;
        private IDatabase repository;
        private IDirectoryManager inputOutputManager;

        public CommandInterpreter(IContentComparer judge, IDatabase repository, IDirectoryManager  inputOutputManager)
        {
            this.judge = judge;
            this.repository = repository;
            this.inputOutputManager = inputOutputManager;
        }

        private void TryFilterAndTake(Match match)
        {
            string courseName = match.Groups[2].Value;
            string filter = match.Groups[3].Value;
            string studentsToTakeStr = match.Groups[4].Value;

            if (int.TryParse(studentsToTakeStr, out int studentsToTake))
            {
                this.repository.FilterAndTake(courseName, filter, studentsToTake);
            }
            else
            {
                this.repository.FilterAndTake(courseName, filter);
            }
        }

        private IExecutable ParseCommand(string input, string commandName)
        {
            if (!Patterns.PatternsByCommands.ContainsKey(commandName))
            {
                throw new CommandNotFoundExeption(commandName);
            }

            Match match = Patterns.PatternsByCommands[commandName].Match(input);

            if (!match.Success)
            {
                throw new InvalidCommandException(input);
            }

            object[] parametersForConstruction = new object[]
            {
                match
            };

            Type commandType = Assembly.GetExecutingAssembly()
                .GetTypes()
                .First(t => t.GetCustomAttributes()
                    .Any(a => a.GetType() == typeof(AliasAttribute) &&
                        ((AliasAttribute) a).Name == commandName));

            Type interpreterType = typeof(CommandInterpreter);

            IExecutable command = (IExecutable) Activator
                .CreateInstance(commandType, parametersForConstruction);

            FieldInfo[] fieldsOfCommand = commandType
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            FieldInfo[] fieldsOfInterpreter = interpreterType
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (FieldInfo fieldOfCommand 
                in fieldsOfCommand
                    .Where(field => field.CustomAttributes
                        .Any(atr => atr.AttributeType == typeof(InjectAttribute))))
            {
                FieldInfo interpreterMatchingField = fieldsOfInterpreter
                    .FirstOrDefault(field => field.FieldType == fieldOfCommand.FieldType);

                if (interpreterMatchingField != null)
                {
                    fieldOfCommand.SetValue(command,
                        interpreterMatchingField.GetValue(this));
                }
            }

            return command;
        }

        public void InterpretCommand(string input)
        {
            if (input == string.Empty)
            {
                return;
            }

            string commandName =
                input.Split(new[] { ' ', '\t' },
                    StringSplitOptions.RemoveEmptyEntries)
                .First();

            try
            {
                IExecutable command = this.ParseCommand(input, commandName);
                command.Execute();
            }
            catch (Exception ex)
            {
                OutputWriter.DisplayException(ex.Message);
            }
        }
    }
}