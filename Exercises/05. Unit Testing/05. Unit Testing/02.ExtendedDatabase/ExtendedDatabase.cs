using System;
using System.Linq;

public class ExtendedDatabase
{
    private const int RequiredCapacity = 16;

    private int currentIndex;
    private int capacity;
    private IPerson[] users;

    public ExtendedDatabase()
        : this(RequiredCapacity)
    { }

    public ExtendedDatabase(int capacity, params IPerson[] people)
    {
        this.currentIndex = 0;
        this.Capacity = capacity;
        this.users = new IPerson[this.Capacity];

        foreach (IPerson person in people)
        {
            this.Add(person);
        }
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

    public void Add(IPerson user)
    {
        if (currentIndex == this.Capacity)
        {
            throw new InvalidOperationException();
        }

        if (this.users.Take(this.currentIndex).Any(u => u.Username == user.Username ||
            u.Id == user.Id))
        {
            throw new InvalidOperationException();
        }

        this.users[this.currentIndex++] = user;
    }

    public void Remove()
    {
        if (this.currentIndex == 0)
        {
            throw new InvalidOperationException();
        }

        this.users[this.currentIndex--] = null;
    }

    public IPerson FindByUsername(string username)
    {
        if (username == null)
        {
            throw new ArgumentNullException();
        }

        IPerson user = this.users
            .Take(this.currentIndex)
            .FirstOrDefault(u => u.Username == username);

        if (user == null)
        {
            throw new InvalidOperationException();
        }

        return user;
    }

    public IPerson FindById(long id)
    {
        IPerson user = this.users
            .Take(this.currentIndex)
            .FirstOrDefault(u => u.Id == id);

        if (user == null)
        {
            throw new InvalidOperationException();
        }

        if (this.users.Take(this.currentIndex).Any(u => u.Id < 0))
        {
            throw new ArgumentOutOfRangeException();
        }

        return user;
    }
}