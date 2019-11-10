using System.Text.RegularExpressions;

using BashSoft.Attributes;
using BashSoft.Contracts;

namespace BashSoft.IO.Commands
{
    [Alias("cdAbs")]
    public class ChangeAbsolutePathCommand : Command, IExecutable
    {
        [Inject]
        private IDirectoryManager inputOutputManager;

        public ChangeAbsolutePathCommand(Match match)
            : base(match)
        { }

        public override void Execute()
        {
            string absolutePath = base.Match.Groups[2].Value;

            this.inputOutputManager.ChangeCurrentDirectoryAbsolute(absolutePath);
        }
    }
}