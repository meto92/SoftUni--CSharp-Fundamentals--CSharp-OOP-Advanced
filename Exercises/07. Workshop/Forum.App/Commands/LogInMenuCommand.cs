using Forum.App.Contracts;

namespace Forum.App.Commands
{
    public class LogInMenuCommand : Command
    {
        public LogInMenuCommand(IMenuFactory menuFactory)
            : base(menuFactory)
        { }
    }
}