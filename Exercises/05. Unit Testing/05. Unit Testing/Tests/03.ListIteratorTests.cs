using System.Linq;
using System.Reflection;

using NUnit.Framework;

public class ListIteratorTests
{
    private const int ElementsCount = 10;
    private const string IndexNotFoundMessage = "Iterator index not found.";
    
    private FieldInfo iteratorInternalIndexField = typeof(ListIterator)
        .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
        .FirstOrDefault(f => f.Name.ToLower().Contains("index"));

    private void EnsureIteratorInternalIndexFIels()
    {
        if (this.iteratorInternalIndexField == null)
        {
            Assert.Fail(IndexNotFoundMessage);
        }
    }

    [Test]
    public void InitializingListIteratorWithNullShouldThrowException()
    {
        Assert.That(() => new ListIterator(null),
            Throws.ArgumentNullException,
            "Initializing list iterator with null didn't throw exception.");
    }

    [Test]
    public void MoveShouldReturnFalseAndNotIncreaseIndexWhenListIsEmpty()
    {
        EnsureIteratorInternalIndexFIels();

        ListIterator iterator = new ListIterator(new string[0]);

        bool actualMove = iterator.Move();

        Assert.That(this.iteratorInternalIndexField.GetValue(iterator),
            Is.EqualTo(0),
            "Move changed index when list is empty.");

        Assert.That(actualMove, Is.EqualTo(false),
            "Move didn't return false when list is empty.");
    }

    [Test]
    public void MoveShouldReturnFalseAndNotIncreaseIndexWhenListHasOneElement()
    {
        EnsureIteratorInternalIndexFIels();

        ListIterator iterator = 
            new ListIterator(new string[] { string.Empty });

        bool actualMove = iterator.Move();

        Assert.That(this.iteratorInternalIndexField.GetValue(iterator),
            Is.EqualTo(0),
            "Move changed index when list has one element.");

        Assert.That(actualMove, Is.EqualTo(false),
            "Move didn't return false when list has one element.");
    }

    [Test]
    public void MoveShouldReturnTrueAndIncreaseIndexUntilReachingLastElement()
    {
        EnsureIteratorInternalIndexFIels();

        ListIterator iterator = 
            new ListIterator(Enumerable.Repeat(string.Empty, ElementsCount));

        for (int i = 1; i < ElementsCount; i++)
        {
            Assert.That(iterator.Move(), Is.EqualTo(true),
               "Move returned false before reaching last element.");

            Assert.That(this.iteratorInternalIndexField.GetValue(iterator),
                Is.EqualTo(i),
                "Move didn't update its internal index.");
        }
    }

    [Test]
    public void HasNextShouldReturnFalseWhenListIsEmpty()
    {
        ListIterator iterator = new ListIterator(new string[0]);

        Assert.That(iterator.HasNext, Is.EqualTo(false),
            "HasNext didn't return false when list is empty.");
    }

    [Test]
    public void HasNextShouldReturnFalseWhenListHasOneElement()
    {
        ListIterator iterator = 
            new ListIterator(new string[] { string.Empty });

        bool actualHasNext = iterator.HasNext;

        Assert.That(actualHasNext, Is.EqualTo(false),
            "HasNext didn't return false when list has one element.");
    }

    [Test]
    public void HasNextShouldReturnTrueUntilReachingLastElement()
    {
        ListIterator iterator = 
            new ListIterator(Enumerable.Repeat(string.Empty, ElementsCount));

        for (int i = 1; i < ElementsCount; i++)
        {
            Assert.That(iterator.HasNext, Is.EqualTo(true),
            "HasNext returned false before reaching last element.");
        }
    }

    [Test]
    public void PrintShouldThrowExceptionWhenListIsEmpty()
    {
        ListIterator iterator = new ListIterator(new string[0]);

        Assert.That(() => iterator.Print(),
            Throws.InvalidOperationException
            .With.Message.EqualTo("Invalid Operation!"));
    }
}