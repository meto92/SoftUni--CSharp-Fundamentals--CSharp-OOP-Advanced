using System.Collections;
using System.Collections.Generic;

public class LinkedList<T> : IEnumerable<T>
{
    private class LinkedListNode
    {
        private T value;
        private LinkedListNode pred;
        private LinkedListNode next;

        public LinkedListNode(T value, LinkedListNode prev = null)
        {
            this.value = value;
            this.Prev = prev;
        }

        public T Value
        {
            get => this.value;
            private set => this.value = value;
        }

        public LinkedListNode Prev
        {
            get => this.pred;
            set => this.pred = value;
        }

        public LinkedListNode Next
        {
            get => this.next;
            set => this.next = value;
        }

    }

    private LinkedListNode head;
    private LinkedListNode tail;
    private int count;

    public LinkedList()
    {
        this.head = null;
        this.tail = null;
    }

    public int Count
    {
        get => this.count;
        private set => this.count = value;
    }

    public void Add(T value)
    {
        if (this.Count == 0)
        {
            LinkedListNode newNode = new LinkedListNode(value);

            this.head = newNode;
            this.tail = newNode;
        }
        else
        {
            LinkedListNode newNode = new LinkedListNode(value, this.tail);

            this.tail.Next = newNode;
            this.tail = newNode;
        }

        this.Count++;
    }

    public bool Remove(T value)
    {
        LinkedListNode current = this.head;

        while (current != null && !current.Value.Equals(value))
        {
            current = current.Next;
        }

        if (current != null)
        {
            if (current.Prev != null)
            {
                current.Prev.Next = current.Next;
            }
            else
            {
                this.head = current.Next;
            }

            if (current.Next != null)
            {
                current.Next.Prev = current.Prev;
            }
            else
            {
                this.tail = current.Prev;
            }

            this.Count--;

            return true;
        }

        return false;
    }

    public IEnumerator<T> GetEnumerator()
    {
        LinkedListNode current = this.head;

        while (current != null)
        {
            yield return current.Value;

            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}