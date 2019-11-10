namespace Forum.App.Menus
{
    using System.Collections.Generic;

    using Models;
    using Contracts;

    public class AddReplyMenu : Menu, ITextAreaMenu, IIdHoldingMenu
    {
		private const int AuthorOffset = 8;
		private const int LeftOffset = 18;
		private const int TopOffset = 7;
		private const int ButtonOffset = 14;
        private const string ErrorMessage = "Cannot add an empty reply!";

        private ILabelFactory labelFactory;
        private ICommandFactory commandFactory;
        private IPostService postService;
		private ITextAreaFactory textAreaFactory;
		private IForumReader reader;

		private bool error;
        private int postId;
        private IPostViewModel post;

        public AddReplyMenu(
            ILabelFactory labelFactory,
            ICommandFactory commandFactory,
            IPostService postService,
            ITextAreaFactory textAreaFactory,
            IForumReader reader)
        {
            this.labelFactory = labelFactory;
            this.commandFactory = commandFactory;
            this.postService = postService;
            this.textAreaFactory = textAreaFactory;
            this.reader = reader;
        }

		public ITextInputArea TextArea { get; private set; }

		protected override void InitializeStaticLabels(Position consoleCenter)
		{
            string authorLine = $"Author: {this.post.Author}";

            Position errorPosition = 
				new Position(consoleCenter.Left - ErrorMessage.Length / 2, consoleCenter.Top - 12);
			Position titlePosition =
				new Position(consoleCenter.Left - this.post.Title.Length / 2, consoleCenter.Top - 10);
			Position authorPosition =
				new Position(consoleCenter.Left - authorLine.Length / 2, consoleCenter.Top - 9);

			var labels = new List<ILabel>()
			{
				this.labelFactory.CreateLabel(ErrorMessage, errorPosition, !error),
				this.labelFactory.CreateLabel(this.post.Title, titlePosition),
				this.labelFactory.CreateLabel(authorLine, authorPosition),
			};

			int leftPosition = consoleCenter.Left - LeftOffset;

			int lineCount = this.post.Content.Length;

			// Add post contents
			for (int i = 0; i < lineCount; i++)
			{
				Position position = new Position(leftPosition, consoleCenter.Top - (TopOffset - i));
				ILabel label = this.labelFactory.CreateLabel(this.post.Content[i], position);
				labels.Add(label);
			}

			this.Labels = labels.ToArray();
		}

		protected override void InitializeButtons(Position consoleCenter)
		{
			int left = consoleCenter.Left + ButtonOffset;
			int top = consoleCenter.Top - (TopOffset - this.post.Content.Length);

			this.Buttons = new IButton[3];

			this.Buttons[0] = this.labelFactory.CreateButton("Write", new Position(left, top + 1));
			this.Buttons[1] = this.labelFactory.CreateButton("Submit", new Position(left - 1, top + 11));
			this.Buttons[2] = this.labelFactory.CreateButton("Back", new Position(left + 1, top + 12));
		}

		private void InitializeTextArea()
		{
			Position consoleCenter = Position.ConsoleCenter();

			int top = consoleCenter.Top - (TopOffset + this.post.Content.Length) + 5;

			this.TextArea = this.textAreaFactory.CreateTextArea(this.reader, consoleCenter.Left - 18, top, false);
		}
        
        public override void Open()
        {
            this.InitializeTextArea();
            base.Open();
        }

        private void LoadPost()
        {
            this.post = this.postService.GetPostViewModel(postId);
        }

        public void SetId(int id)
		{
            this.postId = id;

            this.LoadPost();
            this.Open();
		}
        
        public override IMenu ExecuteCommand()
		{
            try
            {
                string commandName = this.CurrentOption.Text;
                ICommand command = this.commandFactory.CreateCommand(commandName);
                IMenu view = command.Execute(this.postId.ToString(), this.TextArea.Text);

                return view;
            }
            catch
            {
                this.error = true;
                this.InitializeStaticLabels(Position.ConsoleCenter());

                return this;
            }
		}
	}
}