namespace FestivalManager
{
	using Core;
	using Core.Controllers;
	using Core.Controllers.Contracts;
	using Core.IO;
	using Core.IO.Contracts;
	using Entities;
	using Entities.Contracts;
    using FestivalManager.Entities.Factories;
    using FestivalManager.Entities.Factories.Contracts;

    public static class StartUp
	{
		public static void Main(string[] args)
		{
			IStage stage = new Stage();
            ISetFactory setFactory = new SetFactory();
            IPerformerFactory performerFactory = new PerformerFactory();
            IInstrumentFactory instrumentFactory = new InstrumentFactory();
            ISongFactory songFactory = new SongFactory();

            IFestivalController festivalController = new FestivalController(
                stage, 
                setFactory, 
                performerFactory, 
                instrumentFactory, 
                songFactory);
			ISetController setController = new SetController(stage);

            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
			Engine engine = new Engine(reader, writer, setController, festivalController);

			engine.Run();
		}
	}
}