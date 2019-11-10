using System;

public class Person : IComparable<Person>
{
    private string name;
    private int age;

    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public string Name
    {
        get => this.name;
        private set => this.name = value;
    }

    public int Age
    {
        get => this.age;
        private set => this.age = value;
    }

    public override int GetHashCode() => this.Name.GetHashCode() * 17 << this.Age;

    public override bool Equals(object obj)
    {
        if (obj == null || !(obj is Person))
        {
            return false;
        }

        Person other = (Person) obj;

        bool areEqual =
            this.Name == other.Name &&
            this.Age == other.Age;

        return areEqual;
    }

    public int CompareTo(Person other)
    {
        int nameComparison = this.Name.CompareTo(other.Name);

        if (nameComparison != 0)
        {
            return nameComparison;
        }

        return this.Age.CompareTo(other.Age);
    }
}