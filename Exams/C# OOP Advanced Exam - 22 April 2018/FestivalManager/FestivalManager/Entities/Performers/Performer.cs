using System;
using System.Collections.Generic;

using FestivalManager.Entities.Contracts;

namespace FestivalManager.Entities.Performers
{
    public class Performer : IPerformer
    {
        private string name;
        private int age;
        private List<IInstrument> instruments;

        public string Name
        {
            get => this.name;
            private set => this.name = value;
        }

        public int Age
        {
            get => this.age;
            private set => this.age = value;
        }

        public IReadOnlyCollection<IInstrument> Instruments => this.instruments;

        public void AddInstrument(IInstrument instrument)
        {
            throw new NotImplementedException();
        }
    }
}