using System.Text.RegularExpressions;

using BashSoft.Attributes;
using BashSoft.Contracts;

namespace BashSoft.IO.Commands
{
    [Alias("cmp")]
    public class CompareFilesCommand : Command, IExecutable
    {
        [Inject]
        private IContentComparer judge;

        public CompareFilesCommand(Match match)
            : base(match)
        { }

        public override void Execute()
        {
            string path1 = base.Match.Groups[2].Value;
            string path2 = base.Match.Groups[4].Value;

            this.judge.CompareContent(path1, path2);
        }
    }
}