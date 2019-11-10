using System;

public class Engine : IEngine
{
    private const string EndCommand = "Enough! Pull back!";

    private IReader reader;
    private IWriter writer;
    private IGameController gameController;

    public Engine(
        IReader reader,
        IWriter writer, 
        IGameController gameController)
    {
        this.reader = reader;
        this.writer = writer;
        this.gameController = gameController;
    }

    public void Run()
    {
        string input = null;

        while ((input = this.reader.ReadLine()) != EndCommand)
        {
            try
            {
                this.gameController.InterpretCommand(input);
            }
            catch (Exception ex)
            {
                this.writer.WriteLine(ex.Message);
            }
        }

        this.gameController.ProduceSummary();
    }
}