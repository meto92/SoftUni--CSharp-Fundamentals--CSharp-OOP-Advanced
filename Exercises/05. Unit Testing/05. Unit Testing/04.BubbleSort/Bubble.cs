using System;

public static class Bubble
{
    private static void Swap<T>(T[] array, int index1, int index2)
    {
        T temp = array[index1];
        array[index1] = array[index2];
        array[index2] = temp;
    }

    public static void BubbleSort<T>(T[] array) where T : IComparable<T>
    {
        for (int upper = array.Length - 1; upper > 0; upper--)
        {
            bool hasSwapped = false;

            for (int i = 0; i < upper; i++)
            {
                if (array[i].CompareTo(array[i + 1]) == 1)
                {
                    Swap(array, i, i + 1);

                    hasSwapped = true;
                }
            }

            if (!hasSwapped)
            {
                break;
            }
        }
    }
}