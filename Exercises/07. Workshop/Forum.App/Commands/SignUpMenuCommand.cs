using Forum.App.Contracts;

namespace Forum.App.Commands
{
    public class SignUpMenuCommand : Command
    {
        public SignUpMenuCommand(IMenuFactory menuFactory)
            : base(menuFactory)
        { }
    }
}