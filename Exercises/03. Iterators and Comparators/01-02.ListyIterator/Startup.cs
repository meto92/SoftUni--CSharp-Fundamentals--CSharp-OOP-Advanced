using System;
using System.Linq;

public class Startup
{
    private static void TryPrint<T>(ListyIterator<T> listyIterator)
    {
        try
        {
            listyIterator.Print();
        }
        catch (InvalidOperationException iopex)
        {
            Console.WriteLine(iopex.Message);
        }
    }

    private static void TryPrintAll<T>(ListyIterator<T> listyIterator)
    {
        try
        {
            listyIterator.PrintAll();
        }
        catch (InvalidOperationException iopex)
        {
            Console.WriteLine(iopex.Message);
        }
    }

    public static void Main()
    {
        ListyIterator<string> listyIterator = new ListyIterator<string>(new string[0]);

        while (true)
        {
            string[] commandParams = Console.ReadLine().Split();

            if (!Enum.TryParse(commandParams[0], out Command command))
            {
                continue;
            }

            object result = null;

            switch (command)
            {
                case Command.Create:
                    if (commandParams.Length > 1)
                    {
                        listyIterator = new ListyIterator<string>(commandParams.Skip(1));
                    }

                    break;
                case Command.Move:
                    result = listyIterator.Move();
                    break;
                case Command.Print:
                    TryPrint(listyIterator);
                    break;
                case Command.PrintAll:
                    TryPrintAll(listyIterator);
                    break;
                case Command.HasNext:
                    result = listyIterator.HasNext;
                    break;
                case Command.END:
                    Environment.Exit(0);
                    break;
            }

            if (result != null)
            {
                Console.WriteLine(result);
            }
        }
    }
}