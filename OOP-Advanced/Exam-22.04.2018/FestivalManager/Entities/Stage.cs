namespace FestivalManager.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;

    public class Stage : IStage
    {
        private readonly List<IPerformer> performers;
        private readonly List<ISong> songs;
        private readonly List<ISet> sets;

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
            //if (HasPerformer(performer.Name))
            //{
            //    throw new InvalidOperationException("Invalid performer provided");

            //}
            //else
            //{
            this.performers.Add(performer);

            //}
        }

        public void AddSet(ISet set)
        {
            //if (HasSet(set.Name))
            //{
            //    throw new InvalidOperationException("Invalid set provided");
            //}
            //else
            //{
            this.sets.Add(set);

            //}

        }

        public void AddSong(ISong song)
        {

            //if (HasSong(song.Name))
            //{
            //    throw new InvalidOperationException("Invalid song provided");

            //}
            //else
            //{
            this.songs.Add(song);

            //}
        }

        public IPerformer GetPerformer(string name)
        {

            //if (!HasPerformer(name))
            //{
            return (IPerformer)this.performers.FirstOrDefault(p => p.Name == name);

            //}
            //else
            //{
            //    throw new InvalidOperationException("Invalid performer provided");
            //}
        }

        public ISet GetSet(string name)
        {

            //if (!HasSet(name))
            //{
            return (ISet)this.sets.FirstOrDefault(s => s.Name == name);

            //}
            //else
            //{
            //    throw new InvalidOperationException("Invalid set provided");
            //}
        }

        public ISong GetSong(string name)
        {

            //if (!HasSong(name))
            //{
            return (ISong)this.songs.FirstOrDefault(s => s.Name == name);

            //}
            //else
            //{
            //    throw new InvalidOperationException("Invalid song provided");
            //}
        }

        public bool HasPerformer(string name)
        {
            return this.Performers.Any(p => p.Name == name);
        }

        public bool HasSet(string name)
        {
            return this.Sets.Any(s => s.Name == name);
        }

        public bool HasSong(string name)
        {
            return this.Songs.Any(s => s.Name == name);
        }
    }
}
