namespace FestivalManager.Tests
{
    using System;

    using NUnit.Framework;

    using FestivalManager.Entities;
    using FestivalManager.Entities.Contracts;
    using FestivalManager.Core.Controllers.Contracts;
    using FestivalManager.Entities.Sets;
    using FestivalManager.Core.Controllers;
    using FestivalManager.Entities.Instruments;

    [TestFixture]
	public class SetControllerTests
    {
        private const string PerformerName = "George";
        private const int PerformerAge = 25;
        private const string SongName = nameof(Song);
        private const int SongMinutes = 5;
        private const int SongSeconds = 10;
        private const int Song2Minutes = 2;
        private const int Song2Seconds = 8;

        private IStage stage;
        private ISetController setController;
        private IPerformer performer;
        private ISet concertSet1;
        private ISet concertSet2;
        private IInstrument instrument;
        private ISong song1;
        private ISong song2;

        [SetUp]
        public void InitObjects()
        {
            this.stage = new Stage();
            this.setController = new SetController(stage);
            this.performer = new Performer(PerformerName, PerformerAge);
            this.concertSet1 = new Short(nameof(Short));
            this.concertSet2 = new Medium(nameof(Medium));
            this.instrument = new Drums();
            this.song1 = new Song(SongName, new TimeSpan(0, SongMinutes, SongSeconds));
            this.song2 = new Song("Song2", new TimeSpan(0, Song2Minutes, Song2Seconds));
        }

		[Test]
	    public void TestNotPerformedSet()
	    {
            this.stage.AddSet(this.concertSet1);
       
            string result = this.setController.PerformSets();

            Assert.That(result, Is.EqualTo("1. Short:\r\n-- Did not perform"));
		}

        [Test]
        public void SetsShouldBeOrderedByActualTime()
        {
            this.concertSet1.AddSong(this.song1);
            this.concertSet1.AddSong(this.song1);
            this.concertSet2.AddSong(this.song1);

            this.stage.AddSet(this.concertSet2);
            this.stage.AddSet(this.concertSet1);

            string result = this.setController.PerformSets();

            Assert.That(result, Is.EqualTo("1. Short:\r\n-- Did not perform\r\n2. Medium:\r\n-- Did not perform"));
        }

        [Test]
        public void TestPerformedSet()
        {
            this.performer.AddInstrument(this.instrument);
            this.concertSet1.AddSong(song1);
            this.concertSet1.AddPerformer(performer);

            this.stage.AddSet(this.concertSet1);
            this.stage.AddSong(song1);
            this.stage.AddPerformer(performer);

            string result = this.setController.PerformSets();

            Assert.That(result, Is.EqualTo($"1. Short:\r\n-- 1. Song ({SongMinutes:D2}:{SongSeconds:D2})\r\n-- Set Successful"));
        }

        [Test]
        public void PerformedSetShouldDecreaseInstrumentWear()
        {
            this.performer.AddInstrument(this.instrument);
            this.concertSet1.AddSong(song1);
            this.concertSet1.AddPerformer(performer);

            this.stage.AddSet(this.concertSet1);
            this.stage.AddSong(song1);
            this.stage.AddPerformer(performer);

            double instrumentWearBeforeConcert = this.instrument.Wear;   

            this.setController.PerformSets();

            double instrumentWearAfterConcert = this.instrument.Wear;

            Assert.That(instrumentWearAfterConcert < instrumentWearBeforeConcert);
        }
    }
}