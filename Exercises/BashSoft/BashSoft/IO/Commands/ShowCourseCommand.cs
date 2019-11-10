using System.Text.RegularExpressions;

using BashSoft.Attributes;
using BashSoft.Contracts;

namespace BashSoft.IO.Commands
{
    [Alias("show")]
    public class ShowCourseCommand : Command, IExecutable
    {
        [Inject]
        private IDatabase repository;

        public ShowCourseCommand(Match match)
            : base(match)
        { }

        public override void Execute()
        {
            string courseName = base.Match.Groups[2].Value;
            string username = base.Match.Groups[4].Value;

            if (username != string.Empty)
            {
                this.repository.GetStudentMarkInCourse(courseName, username);
            }
            else
            {
                this.repository.GetStudentsByCourse(courseName);
            }
        }
    }
}