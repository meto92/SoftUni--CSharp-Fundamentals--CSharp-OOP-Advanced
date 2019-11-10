using System;
using System.Linq;
using System.Collections.Generic;

using NUnit.Framework;

using BashSoft.Contracts;
using BashSoft.DataStructures;

namespace BashSoftTesting
{
    public class OrderedDataStructureTester
    {
        private const int RequiredDefaultCapacity = 16;
        private const int InitialCapacity = 20;
        private const string IncorrectCapacityMessage = "List has incorrect capacity.";
        private const string IncorrectCountMessage = "List has incorrect count.";
        private string[] namesToAdd = new string[]
            {
                "Rosen",
                "Georgi",
                "Balkan"
            };

        private ISimpleOrderedBag<string> names;

        [SetUp]
        public void SetUp()
        {
            this.names = new SimpleSortedList<string>();
        }

        [Test]
        public void TestEmptyCtor()
        {
            this.names = new SimpleSortedList<string>();

            Assert.That(names.Count, Is.EqualTo(0),
                IncorrectCountMessage);
            Assert.That(names.Capacity, Is.EqualTo(16),
                IncorrectCapacityMessage);
        }

        [Test]
        public void TestCtorWithInitialCapacity()
        {
            this.names = new SimpleSortedList<string>(InitialCapacity);

            Assert.That(this.names.Count, Is.EqualTo(0),
                IncorrectCountMessage);
            Assert.That(this.names.Capacity, Is.EqualTo(InitialCapacity),
                IncorrectCapacityMessage);
        }

        [Test]
        public void TestCtorWithAllParams()
        {
            this.names = new SimpleSortedList<string>(
                StringComparer.OrdinalIgnoreCase, 
                InitialCapacity);

            Assert.That(this.names.Capacity, Is.EqualTo(InitialCapacity),
                IncorrectCapacityMessage);
            Assert.That(this.names.Count, Is.EqualTo(0),
                IncorrectCountMessage);
        }

        [Test]
        public void TestCtorWithInitialComparer()
        {
            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase);

            Assert.That(this.names.Capacity, 
                Is.EqualTo(RequiredDefaultCapacity),
                IncorrectCapacityMessage);
            Assert.That(this.names.Count, Is.EqualTo(0),
                IncorrectCountMessage);
        }

        [Test]
        public void TestAddIncreasesSize()
        {
            this.names.Add(string.Empty);

            Assert.That(this.names.Count, Is.EqualTo(1),
                "Adding element didn't increase list's count.");
        }

        [Test]
        public void TestAddNullThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => this.names.Add(null));
        }

        [Test]
        public void TestAddUnsortedDataIsHeldSorted()
        {
            foreach (string name in this.namesToAdd)
            {
                this.names.Add(name);
            }

            Assert.That(this.names, 
                Is.EquivalentTo(this.names.OrderBy(x => x)),
                "Added elements are not held sorted.");
        }

        [Test]
        public void TestAddingMoreThanInitialCapacity()
        {
            for (int i = 0; i <= RequiredDefaultCapacity; i++)
            {
                this.names.Add(string.Empty);
            }

            Assert.That(this.names.Count, 
                Is.EqualTo(RequiredDefaultCapacity + 1),
                IncorrectCountMessage);
            Assert.That(this.names.Capacity, 
                !Is.EqualTo(RequiredDefaultCapacity),
                IncorrectCapacityMessage);
        }

        [Test]
        public void TestAddingAllFromCollectionIncreasesSize()
        {
            List<string> names = new List<string>
            {
                "Rosen",
                "Georgi"
            };

            this.names.AddAll(names);

            Assert.That(this.names.Count, Is.EqualTo(2),
                IncorrectCountMessage);
        }

        [Test]
        public void TestAddingAllFromNullThrowsException()
        {
            Assert.Throws<ArgumentNullException>(
                () => this.names.AddAll(null));
        }

        [Test]
        public void TestAddAllKeepsSorted()
        {
            this.names.AddAll(this.namesToAdd);

            Assert.That(this.names,
                Is.EquivalentTo(this.names.OrderBy(x => x)),
                $"{nameof(SimpleSortedList<string>)} doesn't keep its elements in sorted order.");
        }

        [Test]
        public void TestRemoveValidElementDecreasesSize()
        {
            this.names.Add(this.namesToAdd[0]);
            this.names.Remove(this.namesToAdd[0]);

            Assert.That(this.names.Count, Is.EqualTo(0),
                "Count has incorrect value after removing element.");
        }

        [Test]
        public void TestRemoveValidElementRemovesSelectedOne()
        {
            this.names.Add("Ivan");
            this.names.Add("Nasko");

            this.names.Remove("Ivan");

            Assert.That(this.names.Contains("Ivan"), Is.EqualTo(false));
        }

        [Test]
        public void TestRemovingNullThrowsException()
        {
            Assert.That(() => this.names.Remove(null),
                Throws.ArgumentNullException,
                $"{nameof(SimpleSortedList<string>)} didn't throw exception when tried to remove null.");
        }

        [Test]
        public void TestJoinWithNull()
        {
            this.names.AddAll(this.namesToAdd);

            Assert.That(() => this.names.JoinWith(null),
                Throws.ArgumentNullException,
                $"{nameof(SimpleSortedList<string>)} didn't throw exception when tried to join with null.");
        }

        [Test]
        public void TestJoinWorksFine()
        {
            this.names.AddAll(this.namesToAdd);

            string joinedNamesFromList = this.names.JoinWith(", ");
            string expectedJoin = string.Join(", ", this.names);

            Assert.That(joinedNamesFromList, 
                Is.EquivalentTo(expectedJoin),
                "JoinWith didn't return correct value.");
        }
    }
}