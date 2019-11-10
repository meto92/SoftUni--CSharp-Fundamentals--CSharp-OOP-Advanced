using System;
using System.Linq;
using System.Collections.Generic;

public class Startup
{
    private const string EndCommand = "END";

    private static List<Person> ReadPeople()
    {
        List<Person> people = new List<Person>();

        string input = null;

        while ((input = Console.ReadLine()) != EndCommand)
        {
            string[] personParams = input.Split();

            string name = personParams[0];
            int age = int.Parse(personParams[1]);
            string town = personParams[2];

            Person person = new Person(name, age, town);

            people.Add(person);
        }

        return people;
    }

    public static void Main()
    {
        List<Person> people = ReadPeople();

        int personIndex = int.Parse(Console.ReadLine());

        Person personToCompare = people[personIndex - 1];

        people.Remove(personToCompare);

        int numberOfEqualPeople = people.Count(person => person.CompareTo(personToCompare) == 0) + 1;
        int numberOfNotEqualPeople = people.Count - numberOfEqualPeople + 1;
        int totalNumberOfPeople = people.Count + 1;

        if (numberOfEqualPeople == 1)
        {
            Console.WriteLine("No matches");
        }
        else
        {
            Console.WriteLine("{0} {1} {2}",
                numberOfEqualPeople,
                numberOfNotEqualPeople,
                totalNumberOfPeople);
        }
    }    
}