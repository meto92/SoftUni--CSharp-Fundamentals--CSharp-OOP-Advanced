using System;

public class Startup
{
    public static void Main()
    {
        int commandsCount = int.Parse(Console.ReadLine());

        LinkedList<int> linkedList = new LinkedList<int>();

        for (int i = 0; i < commandsCount; i++)
        {
            string[] commandParams = Console.ReadLine().Split();

            int element = int.Parse(commandParams[1]);

            switch (commandParams[0])
            {
                case "Add":
                    linkedList.Add(element);
                    break;
                case "Remove":
                    linkedList.Remove(element);
                    break;
            }
        }

        Console.WriteLine(linkedList.Count);

        foreach (int number in linkedList)
        {
            Console.Write($"{number} ");
        }

        Console.WriteLine();
    }
}