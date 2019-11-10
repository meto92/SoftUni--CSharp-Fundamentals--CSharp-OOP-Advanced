public class Tweet : ITweet
{
    private string message;

    public Tweet()
        : this(string.Empty)
    { }

    public Tweet(string message)
    {
        this.Message = message;
    }

    public string Message
    {
        get => this.message;
        private set => this.message = value;
    }

    public string RetrieveMessage() => this.Message;
}