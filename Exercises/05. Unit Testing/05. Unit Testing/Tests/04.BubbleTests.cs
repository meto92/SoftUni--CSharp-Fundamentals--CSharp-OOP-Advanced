using System;
using System.Linq;

using NUnit.Framework;

public class BubbleTests
{
    private const int ElementsCount = 100;

    private int[] GenerateIntegers()
    {
        Random rnd = new Random();

        int[] numbers = new int[ElementsCount];

        for (int i = 0; i < ElementsCount; i++)
        {
            numbers[i] = rnd.Next(int.MinValue, int.MaxValue);
        }

        return numbers;
    }

    private double[] GenerateDoubles()
    {
        Random rnd = new Random();

        double[] numbers = new double[ElementsCount];

        for (int i = 0; i < ElementsCount; i++)
        {
            numbers[i] = rnd.NextDouble();
        }

        return numbers;
    }

    [Test]
    public void TestBubbleSortMultipleTimesByIntegers()
    {
        for (int i = 0; i < 50; i++)
        {
            int[] numbers = GenerateIntegers();
            Bubble.BubbleSort(numbers);

            CollectionAssert.AreEqual(numbers, numbers.OrderBy(x => x));
        }
    }

    [Test]
    public void TestBubbleSortMultipleTimesByDoubles()
    {
        for (int i = 0; i < 50; i++)
        {
            double[] numbers = GenerateDoubles();
            Bubble.BubbleSort(numbers);

            CollectionAssert.AreEqual(numbers, numbers.OrderBy(x => x));
        }
    }
}