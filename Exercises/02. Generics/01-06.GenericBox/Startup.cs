using System;
using System.Linq;
using System.Collections.Generic;

public class Startup
{
    private static int ReadInteger()
    {
        return int.Parse(Console.ReadLine());
    }

    private static void TestGenericBoxOfStrings()
    {
        int stringsToReadCount = ReadInteger();

        for (int i = 0; i < stringsToReadCount; i++)
        {
            Console.WriteLine(new Box<string>(Console.ReadLine()));
        }
    }

    private static void TestGenericBoxOfIntegers()
    {
        int integersToReadCount = ReadInteger();

        for (int i = 0; i < integersToReadCount; i++)
        {
            int value = int.Parse(Console.ReadLine());

            Console.WriteLine(new Box<int>(value));
        }
    }
    
    private static void ReadSwapIndices(out int firstIndex, out int secondIndex)
    {
        int[] indices = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .Take(2)
            .ToArray();

        firstIndex = indices[0];
        secondIndex = indices[1];
    }

    private static void ReadBoxesOfStrings(List<Box<string>> boxesOfStrings, int boxesCount)
    {
        for (int i = 0; i < boxesCount; i++)
        {
            Box<string> box = new Box<string>(Console.ReadLine());

            boxesOfStrings.Add(box);
        }
    }

    private static void GenericSwapMethodStrings()
    {
        int boxesCount = ReadInteger();

        List<Box<string>> boxesOfStrings = Box<string>.GetListOfBoxes(boxesCount);

        ReadBoxesOfStrings(boxesOfStrings, boxesCount);

        ReadSwapIndices(out int firstIndex, out int secondIndex);
        Box<string>.Swap(boxesOfStrings, firstIndex, secondIndex);

        Box<string>.PrintBoxes(boxesOfStrings);
    }

    private static void GenericSwapMethodIntegers()
    {
        int boxesCount = ReadInteger();

        List<Box<int>> boxesOfIntegers = Box<int>.GetListOfBoxes(boxesCount);

        for (int i = 0; i < boxesCount; i++)
        {
            int value = int.Parse(Console.ReadLine());

            Box<int> box = new Box<int>(value);

            boxesOfIntegers.Add(box);
        }

        ReadSwapIndices(out int firstIndex, out int secondIndex);
        Box<int>.Swap(boxesOfIntegers, firstIndex, secondIndex);

        Box<int>.PrintBoxes(boxesOfIntegers);
    }

    private static void GenericCountMethodStrings()
    {
        int boxesCount = ReadInteger();

        List<Box<string>> boxesOfStrings = Box<string>.GetListOfBoxes(boxesCount);

        ReadBoxesOfStrings(boxesOfStrings, boxesCount);

        Box<string> element = new Box<string>(Console.ReadLine());

        Console.WriteLine(Box<string>.GetElementsCountGreaterThanGivenElement(
            boxesOfStrings, 
            element));
    }

    private static void GenericCountMethodDoubles()
    {
        int boxesCount = ReadInteger();

        List<Box<double>> boxesOfDoubles = Box<double>.GetListOfBoxes(boxesCount);

        for (int i = 0; i < boxesCount; i++)
        {
            double value = double.Parse(Console.ReadLine());

            Box<double> box = new Box<double>(value);

            boxesOfDoubles.Add(box);
        }

        Box<double> element = new Box<double>(double.Parse(Console.ReadLine()));

        Console.WriteLine(Box<double>.GetElementsCountGreaterThanGivenElement(
            boxesOfDoubles,
            element));
    }

    public static void Main()
    {
        TestGenericBoxOfStrings();
    }
}