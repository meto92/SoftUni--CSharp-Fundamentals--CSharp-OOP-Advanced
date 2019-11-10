using System;
using System.Collections.Generic;

public class Startup
{
    private static void ReadPeople(HashSet<Person> hashSetOfPeople, SortedSet<Person> sortedSetOfPeople)
    {
        int peopleCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < peopleCount; i++)
        {
            string[] personParams = Console.ReadLine().Split();

            string name = personParams[0];
            int age = int.Parse(personParams[1]);

            Person person = new Person(name, age);

            hashSetOfPeople.Add(person);
            sortedSetOfPeople.Add(person);
        }
    }

    public static void Main()
    {
        HashSet<Person> hashSetOfPeople = new HashSet<Person>();
        SortedSet<Person> sortedSetOfPeople = new SortedSet<Person>();

        ReadPeople(hashSetOfPeople, sortedSetOfPeople);

        Console.WriteLine(sortedSetOfPeople.Count);
        Console.WriteLine(hashSetOfPeople.Count);
    }
}