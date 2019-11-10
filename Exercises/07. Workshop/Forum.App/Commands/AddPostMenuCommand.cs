using Forum.App.Contracts;

namespace Forum.App.Commands
{
    public class AddPostMenuCommand : Command
    {
        public AddPostMenuCommand(IMenuFactory menuFactory)
            : base(menuFactory)
        { }
    }
}