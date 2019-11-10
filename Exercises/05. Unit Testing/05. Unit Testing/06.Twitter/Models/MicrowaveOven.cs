public class MicrowaveOven : IClient
{
    private IOutputWriter writer;

    public MicrowaveOven()
        : this(new ConsoleWriter())
    { }

    public MicrowaveOven(IOutputWriter writer)
    {
        this.writer = writer;
    }

    public virtual void WriteMessage(string message)
    {
        this.writer.WriteLine(message);
    }

    public virtual void SendMessageToServer(string message)
    { }

    public void ReceiveTweet(ITweet tweet)
    {
        string message = tweet.RetrieveMessage();

        this.WriteMessage(message);
        this.SendMessageToServer(message);
    }
}