using System.Collections.Generic;

public class Startup
{
    public static void Main()
    {
        IInputReader inputReader = new ConsoleReader();
        IOutputWriter outputWriter = new ConsoleWriter();
        IWeaponRepository weaponRepository = 
            new WeaponRepository(new Dictionary<string, IWeapon>());
        ICommandFactory commandFactory = new CommandFactory();
        IWeaponFactory weaponFactory = new WeaponFactory();
        IGemFactory gemFactory = new GemFactory();

        ICommandInterpreter commandInterpreter = new CommandInterpreter(
            weaponRepository,
            commandFactory,
            weaponFactory,
            gemFactory,
            outputWriter);

        IRunnable engine = new Engine(
            inputReader, 
            outputWriter, 
            commandInterpreter);

        engine.Run();
    }
}