namespace FestivalManager.Entities
{
	using System.Collections.Generic;
	using Contracts;

	public class Stage : IStage
	{
		private readonly List<ISet> sets;
		private readonly List<ISong> songs;
		private readonly List<IPerformer> performers;

        public Stage()
        {
            this.sets = new List<ISet>();
            this.songs = new List<ISong>();
            this.performers = new List<IPerformer>();
        }

        public IReadOnlyCollection<ISet> Sets => this.sets;

        public IReadOnlyCollection<ISong> Songs => this.songs;

        public IReadOnlyCollection<IPerformer> Performers => this.performers;

        public void AddPerformer(IPerformer performer)
        {
            this.performers.Add(performer);
        }

        public void AddSet(ISet performer)
        {
            this.sets.Add(performer);
        }

        public void AddSong(ISong song)
        {
            this.songs.Add(song);
        }

        public bool HasPerformer(string name)
        {
            IPerformer performer = this.performers
                .Find(p => p.Name == name);

            return performer != null;
        }

        public bool HasSet(string name)
        {
            ISet set = this.sets
                .Find(s => s.Name == name);

            return set != null;
        }

        public bool HasSong(string name)
        {
            ISong song = this.songs
                .Find(s => s.Name == name);

            return song != null;
        }

        public IPerformer GetPerformer(string name)
        {
            return this.performers.Find(performer => performer.Name == name);
        }

        public ISet GetSet(string name)
        {
            return this.sets.Find(set => set.Name == name);
        }

        public ISong GetSong(string name)
        {
            return this.songs.Find(song => song.Name == name);
        }
    }
}