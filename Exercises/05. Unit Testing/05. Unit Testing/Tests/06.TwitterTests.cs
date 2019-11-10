using Moq;
using NUnit.Framework;

public class TwitterTests
{
    private const string Message = "message";

    private IOutputWriter writer;

    [SetUp]
    public void InitObjects()
    {
        this.writer = new ConsoleWriter();
    }

    [TestCase(Message)]
    [TestCase("message2")]
    [TestCase("!@#$%^&*()")]
    public void TweetRetrieveMessageShouldReturnGivenMessageToConstructor(string message)
    {
        ITweet tweet = new Tweet(message);

        string retrievedMessage = tweet.RetrieveMessage();

        Assert.That(retrievedMessage, Is.EqualTo(message),
            "RetrieveMessage returned incorrect message.");
    }

    [Test]
    public void ClientShouldWriteMessageAfterReceivingTweet()
    {
        Tweet tweet = Mock.Of<Tweet>();
        MicrowaveOven client = Mock.Of<MicrowaveOven>();

        client.ReceiveTweet(tweet);

        Mock.Get(client).Verify(x =>
            x.WriteMessage(It.IsAny<string>()), Times.Once);
    }

    [Test]
    public void ClientShouldSendMessageToServerAfterReceivingTweet()
    {
        Tweet tweet = Mock.Of<Tweet>();
        MicrowaveOven client = Mock.Of<MicrowaveOven>();
        
        client.ReceiveTweet(tweet);

        Mock.Get(client).Verify(x =>
            x.SendMessageToServer(It.IsAny<string>()), Times.Once);
    }
}