public class Person : IPerson
{
    private long id;
    private string username;

    public Person(long id, string username)
    {
        this.Id = id;
        this.Username = username;
    }

    public long Id
    {
        get => this.id;
        private set => this.id = value;
    }

    public string Username
    {
        get => this.username;
        private set => this.username = value;
    }
}