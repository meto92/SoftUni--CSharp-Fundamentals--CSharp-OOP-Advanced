public interface IClient
{
    void ReceiveTweet(ITweet tweet);

    void WriteMessage(string message);
}