using System.Linq;
using System.Reflection;

using NUnit.Framework;

public class DatabaseTests
{
    private const int RequiredCapacity = 16;

    private Database db;

    [SetUp]
    public void InitDb()
    {
        this.db = new Database();
    }

    [Test]
    public void DbStoringArrayShouldHaveTheRequiredCapacity()
    {
        FieldInfo storingArrayField = typeof(Database)
            .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
            .FirstOrDefault(f => f.FieldType == typeof(int[]));

        if (storingArrayField == null)
        {
            Assert.Fail("Storing array not found.");
        }

        int arrayCapacity = ((int[]) (storingArrayField
            .GetValue(this.db)))
            .Length;

        Assert.That(arrayCapacity, Is.EqualTo(RequiredCapacity), 
            "Db storing array has incorrect capacity.");
    }

    [Test]
    public void DbCapacityPropertyShouldHaveTheRequiredCapacityValue()
    {
        Assert.That(this.db.Capacity, Is.EqualTo(RequiredCapacity),
            "Db Capacity property has incorrect value.");
    }

    [Test]
    public void AddingMoreElementsThanRequiredCapacityShouldThrowException()
    {
        for (int i = 0; i < RequiredCapacity; i++)
        {
            this.db.Add(i);
        }

        Assert.That(() => this.db.Add(0), Throws.InvalidOperationException,
            "Adding more elements than the required capacity didn't throw exception.");
    }

    [Test]
    public void RemovingElementFromEmptyDatabaseShouldThrowException()
    {
        Assert.That(() => this.db.Remove(), Throws.InvalidOperationException,
            "Removing element from empty database didn't throw exception.");
    }

    [TestCase(-1, -2, -3, -4)]
    [TestCase(1, 2, 3, 4, 5, 6, 7, 8, 9, 10)]
    public void FetchShouldReturnAddedElements(params int[] elements)
    {
        this.db = new Database(elements);

        db.Add(1);
        int[] fetchedElements = db.Fetch();

        CollectionAssert.AreEqual(
            elements.Concat(new int[] { 1 }),
            fetchedElements);
    }

    [Test]
    public void FetchEmptyDbShouldReturnEmptyArray()
    {
        int[] fetchedElements = db.Fetch();

        CollectionAssert.AreEqual(new int[0], fetchedElements);
    }
}