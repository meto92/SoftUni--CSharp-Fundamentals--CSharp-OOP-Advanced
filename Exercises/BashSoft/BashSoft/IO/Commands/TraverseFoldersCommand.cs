using System.Text.RegularExpressions;

using BashSoft.Attributes;
using BashSoft.Contracts;

namespace BashSoft.IO.Commands
{
    [Alias("ls")]
    public class TraverseFoldersCommand : Command, IExecutable
    {
        private IDirectoryManager inputOutputManager;

        public TraverseFoldersCommand(Match match)
            : base(match)
        { }

        public override void Execute()
        {
            int depth = int.Parse($"0{base.Match.Groups[3].Value}");
            System.Console.WriteLine(depth);
            this.inputOutputManager.TraverseDirectory(depth);
        }
    }
}