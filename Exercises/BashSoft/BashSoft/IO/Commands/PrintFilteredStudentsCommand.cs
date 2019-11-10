using System.Text.RegularExpressions;

using BashSoft.Attributes;
using BashSoft.Contracts;

namespace BashSoft.IO.Commands
{
    [Alias("filter")]
    public class PrintFilteredStudentsCommand : Command, IExecutable
    {
        [Inject]
        private IDatabase repository;

        public PrintFilteredStudentsCommand(Match match)
            : base(match)
        { }

        public override void Execute()
        {
            string courseName = base.Match.Groups[2].Value;
            string filter = base.Match.Groups[3].Value;
            string studentsToTakeStr = base.Match.Groups[4].Value;

            if (int.TryParse(studentsToTakeStr, out int studentsToTake))
            {
                this.repository.FilterAndTake(courseName, filter, studentsToTake);
            }
            else
            {
                this.repository.FilterAndTake(courseName, filter);
            }
        }
    }
}