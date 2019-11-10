using Forum.App.Contracts;

namespace Forum.App.Commands
{
    public class AddReplyMenuCommand : Command
    {
        public AddReplyMenuCommand(IMenuFactory menuFactory)
            : base(menuFactory)
        { }
    }
}