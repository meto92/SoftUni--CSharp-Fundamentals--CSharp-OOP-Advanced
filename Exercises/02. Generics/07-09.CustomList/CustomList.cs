using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class CustomList<T> : IEnumerable<T> where T : IComparable<T>
{
    private List<T> elements;

    public CustomList()
    {
        this.elements = new List<T>();
    }

    public void Add(T element)
    {
        this.elements.Add(element);
    }

    public T Remove(int index)
    {
        T element = this.elements[index];

        this.elements.RemoveAt(index);

        return element;
    }

    public bool Contains(T element)
    {
        return this.elements.Contains(element);
    }

    public void Swap(int index1, int index2)
    {
        T temp = this.elements[index1];

        this.elements[index1] = this.elements[index2];
        this.elements[index2] = temp;
    }

    public int CountGreaterThan(T element)
    {
        int count = this.elements.Count(e => e.CompareTo(element) == 1);

        return count;
    }

    private T GetMax()
    {
        T max = this.elements[0];

        for (int i = 1; i < this.elements.Count; i++)
        {
            T currentElement = this.elements[i];

            if (currentElement.CompareTo(max) == 1)
            {
                max = currentElement;
            }
        }

        return max;
    }

    public T Max()
    {
        T max = this.GetMax();

        return max;
    }

    private T GetMi()
    {
        T min = this.elements[0];

        for (int i = 1; i < this.elements.Count; i++)
        {
            T currentElement = this.elements[i];

            if (currentElement.CompareTo(min) == -1)
            {
                min = currentElement;
            }
        }

        return min;
    }

    public T Min()
    {
        T min = this.GetMi();

        return min;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return this.elements.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public void Sort()
    {
        this.elements.Sort();
    }
}