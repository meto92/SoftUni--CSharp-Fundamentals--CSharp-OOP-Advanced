using System;

public class Startup
{
    public static void Main()
    {
        CustomList<string> customListOfStrings = new CustomList<string>();

        while (true)
        {
            string[] commandParams = Console.ReadLine().Split();

            Command command = Enum.Parse<Command>(commandParams[0], true);

            string element = null;
            object result = null;

            switch (command)
            {
                case Command.Add:
                    element = commandParams[1];
                    customListOfStrings.Add(element);
                    break;
                case Command.Remove:
                    int index = int.Parse(commandParams[1]);

                    customListOfStrings.Remove(index);
                    break;
                case Command.Contains:
                    element = commandParams[1];

                    result = customListOfStrings.Contains(element);
                    break;
                case Command.Swap:
                    int firstIndex = int.Parse(commandParams[1]),
                        secondIndex = int.Parse(commandParams[2]);

                    customListOfStrings.Swap(firstIndex, secondIndex);
                    break;
                case Command.Greater:
                    element = commandParams[1];
                    result = customListOfStrings.CountGreaterThan(element);
                    break;
                case Command.Max:
                    result = customListOfStrings.Max();
                    break;
                case Command.Min:
                    result = customListOfStrings.Min();
                    break;
                case Command.Sort:
                    Sorter.Sort(customListOfStrings);
                    break;
                case Command.Print:
                    result = string.Join(Environment.NewLine, customListOfStrings);
                    break;
                case Command.End:
                    return;
            }

            if (result != null)
            {
                Console.WriteLine(result);
            }
        }
    }
}