using System;
using System.Linq;

public class Engine : IRunnable
{
    private ICommandInterpreter commandInterpreter;

    public Engine(IRepository repository, IUnitFactory unitFactory)
    {
        this.commandInterpreter = new CommandInterpreter(repository, unitFactory);
    }

    public void Run()
    {
        while (true)
        {
            try
            {
                string input = Console.ReadLine();
                string[] data = input.Split();
                string commandName = data[0];
                string result = this.commandInterpreter
                    .InterpretCommand(data.Skip(1).ToArray(), commandName)
                    .Execute();

                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}