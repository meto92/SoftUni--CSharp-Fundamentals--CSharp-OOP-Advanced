using System;
using System.Linq;
using System.Collections.Generic;

public class Box<T> where T : IComparable<T>
{
    private T value;

    public Box(T value)
    {
        this.Value = value;
    }

    public T Value
    {
        get => this.value;
        set => this.value = value;
    }

    public static void Swap(List<Box<T>> elements, int firstIndex, int secondIndex)
    {
        Box<T> temp = elements[firstIndex];

        elements[firstIndex] = elements[secondIndex];
        elements[secondIndex] = temp;
    }

    public static List<Box<T>> GetListOfBoxes(int count)
    {
        return new List<Box<T>>(count);
    }

    public static void PrintBoxes(List<Box<T>> boxes)
    {
        boxes.ForEach(Console.WriteLine);
    }

    public static int GetElementsCountGreaterThanGivenElement(IList<Box<T>> elements, Box<T> element)
    {
        int count = elements.Count(e => e.value.CompareTo(element.value) == 1);

        return count;
    }

    public override string ToString()
    {
        string result = $"{this.Value.GetType().FullName}: {this.Value}";

        return result;
    }
}