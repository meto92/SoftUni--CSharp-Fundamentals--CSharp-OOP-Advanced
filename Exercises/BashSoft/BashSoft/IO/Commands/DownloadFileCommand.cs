using System.Text.RegularExpressions;

using BashSoft.Attributes;
using BashSoft.Contracts;

namespace BashSoft.IO.Commands
{
    [Alias("download")]
    public class DownloadFileCommand : Command, IExecutable
    {
        [Inject]
        private IDirectoryManager inputOutputManager;

        public DownloadFileCommand(Match match)
            : base(match)
        { }

        public override void Execute()
        {
            string filePath = base.Match.Groups[2].Value;

            this.inputOutputManager.DownloadFile(filePath);
        }
    }
}