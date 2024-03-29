﻿using Forum.App.Contracts;

namespace Forum.App.Commands
{
    public abstract class Command : ICommand
    {
        private const string CommandSuffix = nameof(Command);

        private IMenuFactory menuFactory;

        protected Command(IMenuFactory menuFactory)
        {
            this.menuFactory = menuFactory;
        }

        public IMenu Execute(params string[] args)
        {
            string commandName = this.GetType().Name;
            string menuName = commandName.Substring(0, commandName.Length - CommandSuffix.Length);

            IMenu menu = this.menuFactory.CreateMenu(menuName);

            return menu;
        }
    }
}