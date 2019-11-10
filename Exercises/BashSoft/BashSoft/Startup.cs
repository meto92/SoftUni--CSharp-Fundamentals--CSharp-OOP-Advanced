using BashSoft.Contracts;
using BashSoft.IO;
using BashSoft.Judge;
using BashSoft.Repository;

public class Startup
{
    public static void Main()
    {
        IContentComparer tester = new Tester();
        IDirectoryManager ioManager = new IOManager();
        IDatabase repository = new StudentsRepository(
            new RepositorySorter(),
            new RepositoryFilter());

        IInterpreter currentInterpreter = new CommandInterpreter(tester, repository, ioManager);
        IReader reader = new InputReader(currentInterpreter);

        reader.StartReadingCommands();
    }
}