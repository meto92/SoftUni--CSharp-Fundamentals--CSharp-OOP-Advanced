using CustomLinkedList;
using NUnit.Framework;
using System;

public class CustomLinkedListTests
{
    private const int ElementsCount = 50;

    private DynamicList<int> intsList;

    [SetUp]
    public void InitList()
    {
        this.intsList = new DynamicList<int>();
    }

    [TestCase(-1)]
    [TestCase(0)]
    [TestCase(1)]
    public void IndexerGetterShouldThrowExceptionWhenInvalidIndexIsGiven(int index)
    {
        int value = 0;

        Assert.Throws<ArgumentOutOfRangeException>(
            () => value = this.intsList[index],
            "List didn't throw exception when invalid index was given to indexer.");
    }

    [TestCase(-1)]
    [TestCase(0)]
    [TestCase(1)]
    public void IndexerSetterShouldThrowExceptionWhenInvalidIndexIsGiven(int index)
    {
        Assert.Throws<ArgumentOutOfRangeException>(
            () => this.intsList[index] = 0,
            "List didn't throw exception when invalid index was given to indexer.");
    }

    [Test]
    public void AddShouldIncreaseCount()
    {
        for (int i = 0; i < ElementsCount; i++)
        {
            this.intsList.Add(i);

            Assert.That(this.intsList.Count, Is.EqualTo(i + 1),
                "Add didn't upgrade count.");
        }
    }

    [Test]
    public void IndexerShouldReturnCorrectValue()
    {
        for (int i = 0; i < ElementsCount; i++)
        {
            this.intsList.Add(i);

            Assert.That(this.intsList[i], Is.EqualTo(i),
                "Indexer diddn't return correct value.");
        }
    }

    [TestCase(-1)]
    [TestCase(0)]
    [TestCase(1)]
    public void RemoveAtShouldThrowExceptionWhenInvalidIndexIsGiven(int index)
    {
        Assert.Throws<ArgumentOutOfRangeException>(
            () => this.intsList.RemoveAt(index),
            "RemoveAt didn't throw exception when invalid index was given to.");
    }

    [Test]
    public void RemoveAtShouldDecreaseCount()
    {
        this.intsList.Add(0);

        this.intsList.RemoveAt(0);

        Assert.That(this.intsList.Count, Is.EqualTo(0),
            "Remove didn't decrease count.");
    }

    [Test]
    public void RemoveAtShouldReturnCorrectElement()
    {
        for (int i = 0; i < ElementsCount; i++)
        {
            this.intsList.Add(i);
        }

        for (int i = 0; i < ElementsCount; i++)
        {
            int element = this.intsList.RemoveAt(0);

            Assert.That(element, Is.EqualTo(i),
                "RemoveAt didn't return correct element");
        }
    }

    [Test]
    public void RemoveShouldDecreaseCount()
    {
        this.intsList.Add(0);

        this.intsList.Remove(0);

        Assert.That(this.intsList.Count, Is.EqualTo(0),
            "Remove didn't decrease count.");
    }

    [Test]
    public void RemoveShouldReturnMinusOneWhenElementIsNotFound()
    {
        this.intsList.Add(1);

        int index = this.intsList.Remove(0);

        Assert.That(index, Is.EqualTo(-1),
            "Remove didn't return -1 when element was not found.");
    }

    [Test]
    public void RemoveShouldReturnFirstIndexOfFoundElement()
    {
        for (int i = 0; i < ElementsCount; i++)
        {
            this.intsList.Add(1);
        }

        int index = this.intsList.Remove(1);

        Assert.That(index, Is.EqualTo(0),
            "Remove didn't return first index of found element");
    }

    [Test]
    public void IndexOfShouldReturnMinusOneWhenElementIsNotFound()
    {
        this.intsList.Add(1);

        int index = this.intsList.Remove(0);

        Assert.That(index, Is.EqualTo(-1),
            "IndexOf didn't return -1 when element was not found.");
    }

    [Test]
    public void IndexOfShouldReturnFirstIndexOfFoundElement()
    {
        for (int i = 0; i < ElementsCount; i++)
        {
            this.intsList.Add(1);
        }

        int index = this.intsList.IndexOf(1);

        Assert.That(index, Is.EqualTo(0),
            "IndexOf didn't return first index of found element.");
    }

    [Test]
    public void ContainsShouldReturnFalseWhenElementIsNotPresentInTheList()
    {
        this.intsList.Add(0);

        bool actualContains = this.intsList.Contains(1);

        Assert.That(actualContains, Is.EqualTo(false),
            "Contains returned true when given element wasn't present in the list.");
    }

    [Test]
    public void ContainsShouldReturnTrueWhenElementIsPresentInTheList()
    {
        for (int i = 0; i < ElementsCount; i++)
        {
            this.intsList.Add(i);
        }

        for (int i = 0; i < ElementsCount; i++)
        {
            Assert.That(this.intsList.Contains(i), Is.EqualTo(true),
            "Contains returned false when given element was present in the list.");
        }
    }
}