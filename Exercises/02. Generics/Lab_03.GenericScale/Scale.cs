using System;

public class Scale<T> where T : IComparable<T>
{
    private T left;
    private T right;

    public Scale(T left, T right)
    {
        this.Left = left;
        this.Right = right;
    }

    public T Left
    {
        get => this.left;
        private set => this.left = value;
    }

    public T Right
    {
        get => this.right;
        private set => this.right = value;
    }

    public T GetHeavier()
    {
        int cmp = this.Left.CompareTo(this.Right);

        if (cmp == -1)
        {
            return this.Right;
        }

        if (cmp == 1)
        {
            return this.Left;
        }

        return default(T);
    }
}