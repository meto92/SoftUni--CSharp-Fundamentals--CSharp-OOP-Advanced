using System;
using System.Collections.Generic;

public class Book : IComparable<Book>
{
    private string title;
    private int year;
    private List<string> authors;
    
    public Book(string title, int year, params string[] authors)
    {
        this.Title = title;
        this.Year = year;
        this.authors = new List<string>(authors);
    }

    public string Title
    {
        get => this.title;
        private set => this.title = value;
    }

    public int Year
    {
        get => this.year;
        private set => this.year = value;
    }

    public IReadOnlyList<string> Authors => this.authors;

    public int CompareTo(Book other)
    {
        if (this.Year != other.Year)
        {
            return this.Year.CompareTo(other.Year);
        }

        return this.Title.CompareTo(other.title);
    }

    public override string ToString()
    {
        return $"{this.Title} - {this.Year}";
    }
}