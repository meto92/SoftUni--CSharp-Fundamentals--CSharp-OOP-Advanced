namespace FestivalManager.Core.Controllers
{
	using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    using Contracts;
	using Entities.Contracts;
    using FestivalManager.Entities.Factories.Contracts;

    public class FestivalController : IFestivalController
	{
        private const string RegisteredSetMessage = "Registered {0} set";
        private const string RegisteredPerformerMessage = "Registered performer {0}";
        private const string RegisteredSongMessage = "Registered song {0}";
        private const string InvalidSetProvidedMessage = "Invalid set provided";
        private const string InvalidSongProvidedMessage = "Invalid song provided";
        private const string InvalidPerformerProvidedMessage = "Invalid performer provided";
        private const string AddedSongToSetMessage = "Added {0} to {1}";
        private const string AddedPerformerToSetMessage = "Added {0} to {1}";
        private const string RepairedInstrumentsMessage = "Repaired {0} instruments";

        private readonly IStage stage;
        private ISetFactory setFactory;
        private IPerformerFactory performerFactory;
        private IInstrumentFactory instrumentFactory;
        private ISongFactory songFactory;

		public FestivalController(
            IStage stage, 
            ISetFactory setFactory, 
            IPerformerFactory performerFactory,
            IInstrumentFactory instrumentFactory,
            ISongFactory songFactory)
		{
			this.stage = stage;
            this.setFactory = setFactory;
            this.performerFactory = performerFactory;
            this.instrumentFactory = instrumentFactory;
            this.songFactory = songFactory;
		}

		public string RegisterSet(string[] args)
		{
            string name = args[0];
            string type = args[1];

            ISet set = this.setFactory.CreateSet(name, type);

            this.stage.AddSet(set);

            return string.Format(RegisteredSetMessage, type);
		}

		public string SignUpPerformer(string[] args)
		{
			string name = args[0];
			int age = int.Parse(args[1]);

			string[] instrumenti = args.Skip(2).ToArray();

			IPerformer performer = this.performerFactory.CreatePerformer(name, age);

			foreach (var instrumentName in instrumenti)
			{
                IInstrument instrument = this.instrumentFactory.CreateInstrument(instrumentName);

                performer.AddInstrument(instrument);
			}

			this.stage.AddPerformer(performer);

            return string.Format(RegisteredPerformerMessage, name);
		}

		public string RegisterSong(string[] args)
		{
            string name = args[0];
            string[] durationArgs = args[1].Split(':');

            int minutes = int.Parse(durationArgs[0]);
            int seconds = int.Parse(durationArgs[1]);

            TimeSpan duration = new TimeSpan(0, minutes, seconds);

            ISong song = this.songFactory.CreateSong(name, duration);

            this.stage.AddSong(song);

            return string.Format(RegisteredSongMessage, song);
		}

		public string AddSongToSet(string[] args)
		{
			string songName = args[0];
			string setName = args[1];

			if (!this.stage.HasSet(setName))
			{
				throw new InvalidOperationException(InvalidSetProvidedMessage);
			}

			if (!this.stage.HasSong(songName))
			{
				throw new InvalidOperationException(InvalidSongProvidedMessage);
			}

			ISet set = this.stage.GetSet(setName);
			ISong song = this.stage.GetSong(songName);

			set.AddSong(song);

            return string.Format(AddedSongToSetMessage, song.ToString(), set.Name);
		}
        
		public string AddPerformerToSet(string[] args)
		{
            string performerName = args[0];
            string setName = args[1];

            if (!this.stage.HasPerformer(performerName))
            {
                throw new InvalidOperationException(InvalidPerformerProvidedMessage);
            }

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException(InvalidSetProvidedMessage);
            }

            IPerformer performer = this.stage.GetPerformer(performerName);
            ISet set = this.stage.GetSet(setName);

            set.AddPerformer(performer);

            return string.Format(AddedPerformerToSetMessage, performerName, setName);
        }

		public string RepairInstruments(string[] args)
		{
			IInstrument[] instrumentsToRepair = this.stage.Performers
				.SelectMany(p => p.Instruments)
				.Where(i => i.Wear < 100)
				.ToArray();

			foreach (IInstrument instrument in instrumentsToRepair)
			{
				instrument.Repair();
			}

            return string.Format(RepairedInstrumentsMessage, instrumentsToRepair.Length);
		}

        public string ProduceReport()
        {
            StringBuilder result = new StringBuilder();

            TimeSpan totalFestivalLength = new TimeSpan(this.stage.Sets.Sum(s => s.ActualDuration.Ticks));

            result.AppendLine($"Festival length: {(int)totalFestivalLength.TotalMinutes:D2}:{totalFestivalLength.Seconds:D2}");

            foreach (ISet set in this.stage.Sets)
            {
                result.AppendLine($"--{set.Name} ({(int)set.ActualDuration.TotalMinutes:D2}:{set.ActualDuration.Seconds:D2}):");

                IEnumerable<IPerformer> performersOrderedDescendingByAge = set.Performers
                    .OrderByDescending(p => p.Age);

                foreach (IPerformer performer in performersOrderedDescendingByAge)
                {
                    var instruments = string.Join(", ", performer.Instruments
                        .OrderByDescending(i => i.Wear));

                    result.AppendLine($"---{performer.Name} ({instruments})");
                }

                if (!set.Songs.Any())
                {
                    result.AppendLine("--No songs played");
                }
                else
                {
                    result.AppendLine("--Songs played:");

                    foreach (var song in set.Songs)
                    {
                        result.AppendLine($"----{song.ToString()}");
                    }
                }
            }

            return result.ToString().TrimEnd();
        }
    }
}