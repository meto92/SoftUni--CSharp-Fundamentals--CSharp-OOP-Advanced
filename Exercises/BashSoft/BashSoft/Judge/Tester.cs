using System;
using System.IO;

using BashSoft.Contracts;
using BashSoft.IO;

namespace BashSoft.Judge
{
    public class Tester : IContentComparer
    {
        public string GetMismatchPapth(string expectedOutputPath)
        {
            int index = expectedOutputPath.LastIndexOf('\\');
            string directoryPath = expectedOutputPath.Substring(0, index);
            string mismatchPath = directoryPath + @"\Mismatches.txt";

            return mismatchPath;
        }

        private string[] GetLineWithPossibleMismatches(string[] actualOutputLines, string[] expectedOutputLines, out bool hasMismatch)
        {
            hasMismatch = false;

            OutputWriter.WriteMessageOnNewLine("Comparing files...");

            int minOutputLines = actualOutputLines.Length;

            if (actualOutputLines.Length != expectedOutputLines.Length)
            {
                hasMismatch = true;
                minOutputLines = Math.Min(actualOutputLines.Length, expectedOutputLines.Length);
                OutputWriter.DisplayException(ExceptionMessages.ComparisonOfFilesWithDifferentSizes);
            }

            string[] mismatches = new string[minOutputLines];

            for (int index = 0; index < minOutputLines; index++)
            {
                string actualLine = actualOutputLines[index];
                string expectedLine = expectedOutputLines[index];
                string output = string.Empty;

                if (actualLine != expectedLine)
                {
                    output = $@"Mismatch at line {index} -- expected: ""{expectedLine}"", actual: ""{actualLine}""";
                    hasMismatch = true;
                }
                else
                {
                    output = actualLine;
                }

                mismatches[index] = $"{output}{Environment.NewLine}";
            }

            return mismatches;
        }

        private void PrintOutput(string[] mismatches, bool hasMismatch, string mismatchFiePath)
        {
            if (hasMismatch)
            {
                foreach (string line in mismatches)
                {
                    OutputWriter.WriteMessageOnNewLine(line);
                }

                File.WriteAllLines(mismatchFiePath, mismatches);
            }
            else
            {
                OutputWriter.WriteMessageOnNewLine("Files are identical. There are no mismatches.");
            }
        }

        public void CompareContent(string userOutputPath, string expectedOutputPath)
        {
            OutputWriter.WriteMessageOnNewLine("Reading files...");

            try
            {
                File.GetAccessControl(userOutputPath);
                File.GetAccessControl(expectedOutputPath);
            }
            catch (FileNotFoundException)
            {
                throw new InvalidPathException();
            }
            catch (UnauthorizedAccessException)
            {
                throw new UnauthorizedAccessException(ExceptionMessages.UnauthorizesExceptionMessage);
            }

            string mismatchFiePath = GetMismatchPapth(expectedOutputPath);

            string[] actualOutputLines = File.ReadAllLines(userOutputPath);
            string[] expectedOutputLines = File.ReadAllLines(expectedOutputPath);

            string[] mismatches = GetLineWithPossibleMismatches(actualOutputLines, expectedOutputLines, out bool hasMismatch);

            PrintOutput(mismatches, hasMismatch, mismatchFiePath);
            OutputWriter.WriteMessageOnNewLine("Files read!");
        }
    } 
}