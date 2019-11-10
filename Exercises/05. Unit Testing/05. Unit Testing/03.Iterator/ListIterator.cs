using System;
using System.Collections;
using System.Collections.Generic;

public class ListIterator : IEnumerable<string>
{
    private const string InvalidOperationExceptionMessage = "Invalid Operation!";

    private List<string> elements;
    private int currentIndex;

    public ListIterator(IEnumerable<string> elements)
    {
        if (elements == null)
        {
            throw new ArgumentNullException();
        }

        this.elements = new List<string>(elements);
        this.currentIndex = 0;
    }

    public bool HasNext => this.currentIndex < this.elements.Count - 1;

    public bool Move()
    {
        if (this.HasNext)
        {
            this.currentIndex++;

            return true;
        }

        return false;
    }

    public void Print()
    {
        if (this.elements.Count == 0)
        {
            throw new InvalidOperationException(InvalidOperationExceptionMessage);
        }

        Console.WriteLine(this.elements[this.currentIndex]);
    }

    public IEnumerator<string> GetEnumerator()
    {
        for (int i = 0; i < this.elements.Count; i++)
        {
            yield return this.elements[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}