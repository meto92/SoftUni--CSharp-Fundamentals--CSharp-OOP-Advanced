using System.Collections.Generic;

public class PersonNameComparrator : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        int nameLengthComparison = x.Name.Length.CompareTo(y.Name.Length);

        if (nameLengthComparison != 0)
        {
            return nameLengthComparison;
        }

        return char.ToUpper(x.Name[0]).CompareTo(char.ToUpper(y.Name[0]));
    }
}