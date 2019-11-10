using System;

public class Person : IComparable<Person>
{
    private string name;
    private int age;
    private string town;

    public Person(string name, int age, string town)
    {
        this.Name = name;
        this.Age = age;
        this.Town = town;
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

    public string Town
    {
        get => this.town;
        private set => this.town = value;
    }

    public int CompareTo(Person other)
    {
        int nameComparison = this.Name.CompareTo(other.Name);

        if (nameComparison != 0)
        {
            return nameComparison;
        }

        int ageComparison = this.Age.CompareTo(other.Age);

        if (ageComparison != 0)
        {
            return ageComparison;
        }

        return this.Town.CompareTo(other.town);
    }
}