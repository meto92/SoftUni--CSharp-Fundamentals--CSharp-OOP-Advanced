using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class Stack<T> : IEnumerable<T>
{
    private const int DefaultCapacity = 4;
    private const string PopExceptionMessage = "No elements";

    private T[] elements;
    private int index;

    public Stack(int capacity = DefaultCapacity)
    {
        this.elements = new T[capacity];
    }

    public Stack(IEnumerable<T> elements)
        : this(elements.Count())
    {
        foreach (T element in elements)
        {
            this.Push(element);
        }
    }

    public int Count => this.index;

    public int Capacity => this.elements.Length;

    private void Resize()
    {
        T[] resized = new T[this.Capacity * 2];

        Array.Copy(this.elements, resized, this.Capacity);

        this.elements = resized;
    }

    public void Push(T element)
    {
        if (this.Count == this.Capacity)
        {
            this.Resize();
        }

        this.elements[this.index++] = element;
    }

    private void Shrink()
    {
        T[] shrinked = new T[this.Count];

        Array.Copy(this.elements, shrinked, this.Count);

        this.elements = shrinked;
    }

    public T Pop()
    {
        if (this.index == 0)
        {
            throw new InvalidOperationException(PopExceptionMessage);
        }

        T poppedElement = this.elements[--this.index];

        this.elements[this.index] = default(T);

        if (this.Count == this.Capacity / 2)
        {
            this.Shrink();
        }

        return poppedElement;
    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = this.index - 1; i >= 0; i--)
        {
            yield return this.elements[i];
        }
    }
}