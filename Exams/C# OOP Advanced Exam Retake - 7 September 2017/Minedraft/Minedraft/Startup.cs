public class Startup
{
    public static void Main()
    {
        IReader reader = new ConsoleReader();
        IWriter writer = new ConsoleWriter();
        IHarvesterFactory harvesterFactory = new HarvesterFactory();
        IEnergyRepository energyRepository = new EnergyRepository();
        IHarvesterController harvesterController = new HarvesterController(harvesterFactory, energyRepository);
        IProviderController providerController = new ProviderController(energyRepository);
        ICommandInterpreter commandInterpreter = 
            new CommandInterpreter(harvesterController, providerController);

        Engine engine = new Engine(reader, writer, commandInterpreter);

        engine.Run();
    }
}