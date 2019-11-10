using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

using BashSoft.Contracts;

namespace BashSoft.DataStructures
{
    public class SimpleSortedList<T> : ISimpleOrderedBag<T> where T : IComparable<T>
    {
        private static class Sorters
        {
            public static void InsertionSort(T[] array, int count)
            {
                for (int i = 1; i < count; i++)
                {
                    int j = i - 1;
                    T element = array[i];

                    while (j >= 0 && element.CompareTo(array[j]) == -1)
                    {
                        array[j + 1] = array[j--];
                    }

                    array[j + 1] = element;
                }
            }

            public static void InsertionSort(T[] array, int count, IComparer<T> comparer)
            {
                for (int i = 1; i < count; i++)
                {
                    int j = i - 1;
                    T element = array[i];

                    while (j >= 0 && comparer.Compare(element, array[j]) == -1)
                    {
                        array[j + 1] = array[j--];
                    }

                    array[j + 1] = element;
                }
            }
        }

        private const int DefaultCapacity = 16;

        private T[] innerCollection;
        private int count;
        private IComparer<T> comparison;

        public SimpleSortedList(int capacity = DefaultCapacity)
            : this(Comparer<T>.Create((x, y) => x.CompareTo(y)), capacity)
        { }

        public SimpleSortedList(IComparer<T> comparison, int capacity = DefaultCapacity)
        {
            this.comparison = comparison;
            this.InitializeInnerCollection(capacity);
        }

        private void InitializeInnerCollection(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentException("Capacity cannot be negative!");
            }

            this.innerCollection = new T[capacity];
        }

        public int Count => this.count;

        public int Capacity => this.innerCollection.Length;

        private void Resize()
        {
            int newCapacity = this.Capacity == 0 
                ? DefaultCapacity
                : this.Count * 2;

            T[] newCollection = new T[newCapacity];

            Array.Copy(this.innerCollection, newCollection, this.Count);

            this.innerCollection = newCollection;
        }

        public void Add(T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException();
            }

            if (this.Count == this.Capacity)
            {
                this.Resize();
            }

            this.innerCollection[this.count++] = element;
            //Array.Sort(this.innerCollection, 0, count);
            Sorters.InsertionSort(this.innerCollection, count);
        }

        private void MultiResize(int collectionElementsCount)
        {
            int newCapacity = this.Capacity * 2;

            while (newCapacity < this.Count + collectionElementsCount)
            {
                newCapacity *= 2;
            }

            T[] newCollection = new T[newCapacity];

            Array.Copy(this.innerCollection, newCollection, this.Count);

            this.innerCollection = newCollection;
        }

        public void AddAll(ICollection<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException();
            }

            if (this.Count + collection.Count > this.Capacity)
            {
                this.MultiResize(collection.Count);
            }

            foreach (T element in collection)
            {
                this.innerCollection[this.count++] = element;
            }

            //Array.Sort(this.innerCollection, 0, this.Count, this.comparison);
            Sorters.InsertionSort(this.innerCollection, this.Count, this.comparison);
        }

        public string JoinWith(string joiner)
        {
            if (joiner == null)
            {
                throw new ArgumentNullException();
            }

            return string.Join(joiner, this.innerCollection.Take(this.Count));
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.innerCollection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        public bool Remove(T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException();
            }

            bool hasBeenRemoved = false;
            int indexOfRemovedElememnt = 0;

            for (int i = 0; i < this.count; i++)
            {
                if (this.innerCollection[i].Equals(element))
                {
                    indexOfRemovedElememnt = i;
                    this.innerCollection[i] = default(T);
                    hasBeenRemoved = true;
                    break;
                }
            }

            if (hasBeenRemoved)
            {
                for (int i = indexOfRemovedElememnt; i < this.Count - 1; i++)
                {
                    this.innerCollection[i] = this.innerCollection[i + 1];
                }

                this.innerCollection[this.Count - 1] = default(T);
                this.count--;
            }

            return hasBeenRemoved;
        }
    }
}