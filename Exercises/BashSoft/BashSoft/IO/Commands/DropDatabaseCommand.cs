using System.Text.RegularExpressions;

using BashSoft.Attributes;
using BashSoft.Contracts;

namespace BashSoft.IO.Commands
{
    [Alias("dropdb")]
    public class DropDatabaseCommand : Command, IExecutable
    {
        [Inject]
        private IDatabase repository;

        public DropDatabaseCommand(Match match)
            : base(match)
        { }

        public override void Execute()
        {
            this.repository.UnloadData();
            OutputWriter.WriteMessageOnNewLine("Database dropped!");
        }
    }
}