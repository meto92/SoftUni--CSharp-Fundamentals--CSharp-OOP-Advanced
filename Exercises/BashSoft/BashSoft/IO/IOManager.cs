using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using BashSoft.Contracts;

namespace BashSoft.IO
{
    public class IOManager : IDirectoryManager
    {
        public string GetCurrentDirectoryPath()
        {
            return SessionData.currentPath;
        }

        private void PrintPaths(int identation, string[] paths)
        {
            if (paths.Length == 0)
            {
                return;
            }

            int lastSlashIndex = paths[0].LastIndexOf('\\');
            string dashes = new string('-', identation + lastSlashIndex);

            for (int i = 0; i < paths.Length; i++)
            {
                string path = paths[i].Substring(lastSlashIndex);

                OutputWriter.WriteMessageOnNewLine($"{dashes}{path}");
            }
        }

        public void TraverseDirectory(int depth)
        {
            OutputWriter.WriteEmptyLine();

            Queue<string> subfolders = new Queue<string>();

            subfolders.Enqueue(GetCurrentDirectoryPath());

            for (int identation = 0; identation <= depth; identation++)
            {
                Queue<string> nextSubfolders = new Queue<string>();

                while (subfolders.Count > 0)
                {
                    string currentDir = subfolders.Dequeue();

                    OutputWriter.WriteMessageOnNewLine($"{new string('-', identation)}{currentDir}");

                    string[] subdirs = new string[0];
                    string[] currentDirFiles = new string[0];

                    try
                    {
                        subdirs = Directory.GetDirectories(currentDir);
                        currentDirFiles = Directory.GetFiles(currentDir);
                    }
                    catch (UnauthorizedAccessException)
                    {
                        OutputWriter.DisplayException(ExceptionMessages.UnauthorizesExceptionMessage);
                    }

                    PrintPaths(identation, subdirs);
                    PrintPaths(identation, currentDirFiles);

                    subdirs.ToList().ForEach(nextSubfolders.Enqueue);
                }

                subfolders = nextSubfolders;
            }
        }

        private string GetFolderCopyName(string existingFolder)
        {
            string firstCopy = $"{existingFolder} - Copy";

            if (!Directory.Exists(firstCopy))
            {
                return firstCopy;
            }

            int copyNumber = 2;

            while (Directory.Exists($"{existingFolder} - Copy({copyNumber})"))
            {
                copyNumber++;
            }

            return $"{existingFolder} - Copy({copyNumber})";
        }

        public void CreateDirectoryInCurrentFolder(string folderName)
        {
            string path = GetCurrentDirectoryPath() + $"\\{folderName}";

            if (Directory.Exists(path))
            {
                path = GetFolderCopyName(path);
            }

            Directory.CreateDirectory(path);
        }

        public void ChangeCurrentDirectoryRelative(string relativePath)
        {
            string oldDirectory = GetCurrentDirectoryPath();
            Regex regex = new Regex($@"(\.{{1,2}}|{Patterns.FileNamePattern})(?=\\|$)");
            MatchCollection matches = regex.Matches(relativePath);

            foreach (Match match in matches)
            {
                string piece = match.Value;

                switch (piece)
                {
                    case ".":
                        break;
                    case "..":
                        try
                        {
                            DirectoryInfo parent = new DirectoryInfo(GetCurrentDirectoryPath()).Parent;
                            SessionData.currentPath = parent.FullName;
                        }
                        catch (NullReferenceException)
                        {
                            SessionData.currentPath = oldDirectory;

                            throw new InvalidPathException();
                        }

                        break;
                    default:
                        string dir = $"{GetCurrentDirectoryPath()}\\{piece}".Replace(@"\\", "\\");

                        bool hasPathChanged = ChangeCurrentDirectoryAbsolute(dir);

                        if (!hasPathChanged)
                        {
                            SessionData.currentPath = oldDirectory;
                            return;
                        }

                        break;
                }
            }
        }

        public bool ChangeCurrentDirectoryAbsolute(string absolutePath)
        {
            if (!Directory.Exists(absolutePath))
            {
                throw new InvalidPathException();
            }

            try
            {
                Directory.GetAccessControl(absolutePath);
                SessionData.currentPath = absolutePath;
            }
            catch (UnauthorizedAccessException)
            {
                throw new UnauthorizedAccessException(ExceptionMessages.UnauthorizesExceptionMessage);
            }

            return true;
        }

        private string GetFileCopyPath(string existingFilePath)
        {
            FileInfo file = new FileInfo(existingFilePath);
            string fileDirectory = file.DirectoryName;
            string fileNameWithoutExtension = file.Name.Substring(0, file.Name.IndexOf('.'));
            string firstCopyName = $"{fileDirectory}\\{fileNameWithoutExtension} - Copy{file.Extension}";

            if (!File.Exists(firstCopyName))
            {
                return firstCopyName;
            }

            int copyNumber = 2;

            while (File.Exists($@"{fileDirectory}\{fileNameWithoutExtension} - Copy({copyNumber}){file.Extension}"))
            {
                copyNumber++;
            }

            return $"{fileDirectory}\\{fileNameWithoutExtension} - Copy({copyNumber}){file.Extension}";
        }

        public void DownloadFile(string filePath)
        {
            try
            {
                FileInfo file = new FileInfo(filePath.TrimEnd('\\', '/'));
                string destination = SessionData.currentPath + $"\\{file.Name}";

                if (File.Exists(destination))
                {
                    destination = GetFileCopyPath(destination);
                }

                File.Copy(file.FullName, destination);
            }
            catch (FileNotFoundException)
            {
                throw new InvalidPathException();
            }
            catch (UnauthorizedAccessException)
            {
                throw new UnauthorizedAccessException(ExceptionMessages.UnauthorizesExceptionMessage);
            }
        }
    } 
}