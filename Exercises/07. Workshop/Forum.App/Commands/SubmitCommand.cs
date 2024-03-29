﻿using Forum.App.Contracts;

namespace Forum.App.Commands
{
    public class SubmitCommand : ICommand
    {
        private ISession session;
        private IPostService postService;
        private ICommandFactory commandFactory;

        public SubmitCommand(
            ISession session,
            IPostService postService,
            ICommandFactory commandFactory)
        {
            this.session = session;
            this.postService = postService;
            this.commandFactory = commandFactory;
        }

        public IMenu Execute(params string[] args)
        {
            int userId = this.session.UserId;

            int postId = int.Parse(args[0]);
            string replyContent = args[1];

            this.postService.AddReplyToPost(postId, replyContent, userId);

            ICommand viewPostCommand = this.commandFactory.CreateCommand("ViewPostMenu");

            return viewPostCommand.Execute(postId.ToString());
        }
    }
}