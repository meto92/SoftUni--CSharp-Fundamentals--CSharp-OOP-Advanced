using Forum.App.Contracts;

namespace Forum.App.Commands
{
    public class AddReplyCommand : ICommand
    {
        private IMenuFactory menuFactory;

        public AddReplyCommand(IMenuFactory menuFactory)
        {
            this.menuFactory = menuFactory;
        }

        public IMenu Execute(params string[] args)
        {
            int postId = int.Parse(args[0]);

            IIdHoldingMenu menu = (IIdHoldingMenu) this.menuFactory.CreateMenu("AddReplyMenu");

            menu.SetId(postId);

            return menu;
        }
    }
}