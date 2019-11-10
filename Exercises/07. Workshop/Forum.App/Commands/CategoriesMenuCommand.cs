using Forum.App.Contracts;

namespace Forum.App.Commands
{
    public class CategoriesMenuCommand : Command
    {
        public CategoriesMenuCommand(IMenuFactory menuFactory)
            : base(menuFactory)
        { }
    }
}