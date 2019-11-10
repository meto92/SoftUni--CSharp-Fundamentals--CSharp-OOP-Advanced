public class LastArmyMain
{
    public static void Main()
    {
        IReader reader = new ConsoleReader();
        IWriter writer = new ConsoleWriter();
        ISoldierFactory soldierFactory = new SoldierFactory();
        IAmmunitionFactory ammunitionFactory = new AmmunitionFactory();
        IMissionFactory missionFactory = new MissionFactory();
        IArmy army = new Army();
        IWareHouse wareHouse = new WareHouse(ammunitionFactory);
        IMissionController missionController = new MissionController(army, wareHouse);
        IGameController gameController = new GameController(
            army,
            writer,
            wareHouse,
            soldierFactory,
            missionFactory,
            missionController);
        IEngine engine = new Engine(reader, writer, gameController);

        engine.Run();
    }
}