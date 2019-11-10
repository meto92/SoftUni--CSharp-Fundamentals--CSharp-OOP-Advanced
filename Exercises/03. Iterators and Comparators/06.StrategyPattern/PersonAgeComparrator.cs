using System.Collections.Generic;

public class PersonAgeComparrator : IComparer<Person>
{
    public int Compare(Person x, Person y) => x.Age.CompareTo(y.Age);
}