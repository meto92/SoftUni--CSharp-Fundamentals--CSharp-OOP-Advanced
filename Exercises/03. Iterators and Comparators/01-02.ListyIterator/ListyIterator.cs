using System;
using System.Collections;
using System.Collections.Generic;

public class ListyIterator<T> : IEnumerable<T>
{
    private const string InvalidOperationExceptionMessage = "Invalid Operation!";

    private List<T> elements;
    private int currentIndex;

    public ListyIterator(IEnumerable<T> elements)
    {
        this.elements = new List<T>(elements);
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

    public void PrintAll()
    {
        Console.WriteLine(string.Join(" ", this.elements));
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.elements.Count; i++)
        {
            yield return this.elements[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}