﻿using System;
using System.Collections;
using System.Collections.Generic;

public class Library : IEnumerable<Book>
{
    private class LibraryIterator : IEnumerator<Book>
    {
        private readonly List<Book> books;
        int currentIndex;

        public LibraryIterator(IEnumerable<Book> books)
        {
            this.Reset();
            this.books = new List<Book>(books);
        }

        public Book Current => this.books[this.currentIndex];

        object IEnumerator.Current => this.Current;

        public void Dispose()
        { }

        public bool MoveNext()
        {
            this.currentIndex++;

            return this.currentIndex < this.books.Count;
        }

        public void Reset() => this.currentIndex = -1;
    }

    private List<Book> books;

    public Library(params Book[] books)
    {
        Array.Sort(books, new BookComparator());

        this.books = new List<Book>(books);
    }

    public IEnumerator<Book> GetEnumerator()
    {
        return new LibraryIterator(this.books);
    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}