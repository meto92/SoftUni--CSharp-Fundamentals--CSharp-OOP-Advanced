using System.Linq;

public class Engine : IRunnable
{
    private const string CommandParamsSeparator = ";";
    private const string EndCommand = "END";

    private IInputReader inputReader;
    private IOutputWriter outputWriter;
    private ICommandInterpreter commandInterpreter;

    public Engine(
        IInputReader inputReader, 
        IOutputWriter outputWriter, 
        ICommandInterpreter commandInterpreter)
    {
        this.inputReader = inputReader;
        this.outputWriter = outputWriter;
        this.commandInterpreter = commandInterpreter;
    }

    public void Run()
    {
        string input = null;

        while ((input = this.inputReader.ReadLine()) != EndCommand)
        {
            string[] commandParams = input.Split(CommandParamsSeparator);

            string commandName = commandParams[0];
            string[] data = commandParams.Skip(1).ToArray();

            this.commandInterpreter.InterpretCommand(data, commandName).Execute();
        }
    }
}