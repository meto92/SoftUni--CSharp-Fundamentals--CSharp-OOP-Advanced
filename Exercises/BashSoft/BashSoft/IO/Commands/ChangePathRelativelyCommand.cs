using System.Linq;
using System.Text.RegularExpressions;

using BashSoft.Attributes;
using BashSoft.Contracts;

namespace BashSoft.IO.Commands
{
    [Alias("cdRel")]
    public class ChangePathRelativelyCommand : Command, IExecutable
    {
        [Inject]
        private IDirectoryManager inputOutputManager;

        public ChangePathRelativelyCommand(Match match)
            : base(match)
        { }

        private string FixSlashes(string path)
        {
            return Regex.Replace(path, @"[\\\/]+", "\\");
        }

        private void TryChangePathRelatively(Match match)
        {
            string matchValue = match.Value;
            int[] indices = { matchValue.IndexOf(' '), matchValue.IndexOf('\t') };
            int index = indices.Where(x => x != -1).First();
            string relativePath = matchValue.Substring(index).Trim();

            this.inputOutputManager.ChangeCurrentDirectoryRelative(FixSlashes(relativePath));
        }

        public override void Execute()
        {
            this.TryChangePathRelatively(base.Match);
        }
    }
}