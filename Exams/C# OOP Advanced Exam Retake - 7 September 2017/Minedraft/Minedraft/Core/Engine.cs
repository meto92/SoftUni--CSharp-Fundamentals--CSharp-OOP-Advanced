using System.Linq;
using System.Collections.Generic;

public class Engine
{
    private const string EndCommand = "Shutdown";

    private IReader reader;
    private IWriter writer;
    private ICommandInterpreter commandInterpreter;

    public Engine(IReader reader, IWriter writer, ICommandInterpreter commandInterpreter)
    {
        this.reader = reader;
        this.writer = writer;
        this.commandInterpreter = commandInterpreter;
    }

    public void Run()
    {
        while (true)
        {
            string input = this.reader.ReadLine().Trim();
            List<string> data = input.Split().ToList();

            try
            {
                string result = this.commandInterpreter.ProcessCommand(data);

                this.writer.WriteLine(result);
            }
            catch
            { }

            if (input == EndCommand)
            {
                break;
            }
        }
    }
}