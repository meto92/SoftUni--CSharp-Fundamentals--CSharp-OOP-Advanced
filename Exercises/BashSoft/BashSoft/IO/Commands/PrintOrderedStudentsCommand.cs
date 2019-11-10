using System.Text.RegularExpressions;

using BashSoft.Attributes;
using BashSoft.Contracts;

namespace BashSoft.IO.Commands
{
    [Alias("order")]
    public class PrintOrderedStudentsCommand : Command, IExecutable
    {
        [Inject]
        private IDatabase repository;

        public PrintOrderedStudentsCommand(Match match)
            : base(match)
        { }

        public override void Execute()
        {
            string courseName = base.Match.Groups[2].Value;
            string comparison = base.Match.Groups[3].Value;
            string studentsToTakeStr = base.Match.Groups[4].Value;

            if (int.TryParse(studentsToTakeStr, out int studentsToTake))
            {
                this.repository.OrderAndTake(courseName, comparison, studentsToTake);
            }
            else
            {
                this.repository.OrderAndTake(courseName, comparison);
            }
        }
    }
}