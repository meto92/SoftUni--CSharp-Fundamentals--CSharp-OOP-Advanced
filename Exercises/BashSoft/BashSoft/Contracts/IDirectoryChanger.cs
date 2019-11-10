namespace BashSoft.Contracts
{
    public interface IDirectoryChanger
    {
        void ChangeCurrentDirectoryRelative(string relativePath);

        bool ChangeCurrentDirectoryAbsolute(string absolutePath);
    }
}