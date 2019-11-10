using System;
using System.Linq;

public class Startup
{
    private static void TryPop<T>(Stack<T> stack)
    {
        try
        {
            stack.Pop();
        }
        catch (InvalidOperationException iopex)
        {
            Console.WriteLine(iopex.Message);
        }
    }

    private static void PrintElements<T>(Stack<T> stack)
    {
        foreach (T elements in stack)
        {
            Console.WriteLine(elements);
        }
    }

    public static void Main()
    {
        Stack<int> ints = new Stack<int>();

        while (true)
        {
            string[] commandParams = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            switch (commandParams[0])
            {
                case "Push":
                    commandParams.Skip(1)
                        .Select(str => int.Parse(str.TrimEnd(',')))
                        .ToList()
                        .ForEach(ints.Push);
                    break;
                case "Pop":
                    TryPop(ints);
                    break;
                case "END":
                    PrintElements(ints);
                    PrintElements(ints);

                    Environment.Exit(0);
                    break;
            }
        }
    }    
}