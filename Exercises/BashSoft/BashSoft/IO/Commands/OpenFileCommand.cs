using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;

using BashSoft.Contracts;
using BashSoft.Attributes;

namespace BashSoft.IO.Commands
{
    [Alias("open")]
    public class OpenFileCommand : Command, IExecutable
    {
        public OpenFileCommand(Match match)
            : base(match)
        { }

        public override void Execute()
        {
            string fileName = base.Match.Groups[2].Value;
            string filePath = $"{SessionData.currentPath}\\{fileName}";

            if (Directory.Exists(filePath))
            {
                OutputWriter.WriteMessageOnNewLine("You are trying to open directory. File is expected.");
                return;
            }

            if (!File.Exists(filePath))
            {
                throw new InvalidPathException();
            }

            Process.Start(filePath);
        }
    }
}