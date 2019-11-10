using NUnit.Framework;

public class ExtendedDatabaseTests
{
    private const int RequiredCapacity = 16;
    private const int FirstPersonId = 1;
    private const string FirstPersonUsername = "username";
    private const int SecondPersonId = 2;
    private const string SecondPersonUsername = "otherUsername";

    private ExtendedDatabase db;

    [SetUp]
    public void InitDb()
    {
        this.db = new ExtendedDatabase();
    }

    [Test]
    public void DbCapacityPropertyShouldHaveTheRequiredCapacityValue()
    {
        Assert.That(db.Capacity, Is.EqualTo(RequiredCapacity),
            "Db storing array has incorrect capacity.");
    }

    [Test]
    public void AddingUsersWithSameIdsShoudThrowException()
    {
        IPerson user1 = new Person(FirstPersonId, FirstPersonUsername);
        IPerson user2 = new Person(FirstPersonId, SecondPersonUsername);
        this.db.Add(user1);

        Assert.That(() => this.db.Add(user2),
            Throws.InvalidOperationException,
            "Adding users with same ids didn't throw exception.");
    }

    [Test]
    public void AddingUsernamesWithSameUsernamesShoudThrowException()
    {
        IPerson user1 = new Person(FirstPersonId, FirstPersonUsername);
        IPerson user2 = new Person(SecondPersonId, FirstPersonUsername);
        this.db.Add(user1);

        Assert.That(() => this.db.Add(user2),
            Throws.InvalidOperationException,
            "Adding users with same usernames didn't throw exception.");
    }

    [Test]
    public void UsernamesShouldBeCaseSensitive()
    {
        IPerson user1 = new Person(
            FirstPersonId, 
            FirstPersonUsername.ToLower());
        IPerson user2 = new Person(
            SecondPersonId, 
            FirstPersonUsername.ToUpper());

        this.db.Add(user1);
        this.db.Add(user2);
    }

    [Test]
    public void RemovingPersonFromEmptyDatabaseShouldThrowException()
    {
        Assert.That(() => this.db.Remove(),
            Throws.InvalidOperationException,
            "Removing user from empty database didn't throw exception.");
    }

    [Test]
    public void FindByUsernameWithNullArgumentShouldThrowException()
    {
        Assert.That(() => this.db.FindByUsername(null),
            Throws.ArgumentNullException,
            "Finding user by username with null argument didn't throw exception.");
    }

    [Test]
    public void FindingInexistingUserByUsernameShouldThrowException()
    {
        Assert.That(() => this.db.FindByUsername(FirstPersonUsername),
            Throws.InvalidOperationException,
            "Trying to find inexisting user by username didn't throw exception.");
    }

    [Test]
    public void FindingInexistingUserByIdShouldThrowException()
    {
        Assert.That(() => this.db.FindById(0),
            Throws.InvalidOperationException,
            "Trying to find inexisting user by id didn't throw exception.");
    }
}