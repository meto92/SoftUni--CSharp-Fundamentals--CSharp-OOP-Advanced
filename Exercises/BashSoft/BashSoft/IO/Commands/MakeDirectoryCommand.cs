using System.Text.RegularExpressions;

using BashSoft.Attributes;
using BashSoft.Contracts;

namespace BashSoft.IO.Commands
{
    [Alias("mkdir")]
    public class MakeDirectoryCommand : Command, IExecutable
    {
        [Inject]
        private IDirectoryManager inputOutputManager;

        public MakeDirectoryCommand(Match match)
            : base(match)
        { }

        public override void Execute()
        {
            string folderName = base.Match.Groups[2].Value;

            this.inputOutputManager.CreateDirectoryInCurrentFolder(folderName);
        }
    }
}