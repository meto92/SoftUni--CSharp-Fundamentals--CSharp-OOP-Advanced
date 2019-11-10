using System.Text.RegularExpressions;

using BashSoft.Contracts;

namespace BashSoft.IO.Commands
{
    public abstract class Command : IExecutable
    {
        private Match match;

        protected Command(Match match)
        {
            this.Match = match;
        }

        protected Match Match
        {
            get => this.match;
            private set => this.match = value;
        }

        public abstract void Execute();
    }
}