using System;
using System.Linq;

public class Database
{
    private const int RequiredCapacity = 16;

    private int currentIndex;
    private int capacity;
    private int[] elements;

    public Database(params int[] elements)
    {
        this.currentIndex = 0;
        this.Capacity = RequiredCapacity;
        this.elements = new int[this.Capacity];

        AddElements(elements);
    }

    private void AddElements(int[] elements)
    {
        if (elements.Length > RequiredCapacity)
        {
            throw new InvalidOperationException();
        }

        Array.Copy(elements, this.elements, elements.Length);

        this.currentIndex = elements.Length;
    }

    public int Capacity
    {
        get => this.capacity;

        private set
        {
            if (value != RequiredCapacity)
            {
                throw new InvalidOperationException();
            }

            this.capacity = value;
        }
    }

    public void Add(int element)
    {
        if (currentIndex == this.Capacity)
        {
            throw new InvalidOperationException();
        }

        this.elements[this.currentIndex++] = element;
    }

    public void Remove()
    {
        if (this.currentIndex == 0)
        {
            throw new InvalidOperationException();
        }

        this.elements[this.currentIndex--] = 0;
    }

    public int[] Fetch()
    {
        return this.elements.Take(this.currentIndex).ToArray();
    }
}