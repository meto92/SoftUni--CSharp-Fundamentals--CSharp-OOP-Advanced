using System.Text.RegularExpressions;

using BashSoft.Attributes;
using BashSoft.Contracts;

namespace BashSoft.IO.Commands
{
    [Alias("readDb")]
    public class ReadDatabaseCommand : Command, IExecutable
    {
        [Inject]
        private IDatabase repository;

        public ReadDatabaseCommand(Match match)
            : base(match)
        { }

        public override void Execute()
        {
            string fileName = base.Match.Groups[2].Value;

            this.repository.LoadData(fileName);
        }
    }
}