using System;
using System.Collections.Generic;

public class Startup
{
    private static void ReadPeople(SortedSet<Person> setImplementedNameComparator, SortedSet<Person> setImplementedAgeComparator)
    {
        int peopleCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < peopleCount; i++)
        {
            string[] personParams = Console.ReadLine().Split();

            string name = personParams[0];
            int age = int.Parse(personParams[1]);

            Person person = new Person(name, age);

            setImplementedNameComparator.Add(person);
            setImplementedAgeComparator.Add(person);
        }
    }

    private static void Print(SortedSet<Person> people)
    {
        foreach (Person person in people)
        {
            Console.WriteLine(person);
        }
    }

    public static void Main()
    {
        SortedSet<Person> setImplementedNameComparator 
            = new SortedSet<Person>(new PersonNameComparrator());
        SortedSet<Person> setImplementedAgeComparator
            = new SortedSet<Person>(new PersonAgeComparrator());

        ReadPeople(setImplementedNameComparator, setImplementedAgeComparator);
        
        Print(setImplementedNameComparator);
        Print(setImplementedAgeComparator);
    }    
}