﻿using System;
using System.Linq;

public class Startup
{
    public static void Main()
    {
        int[] stones = Console.ReadLine()
            .Split(", ")
            .Select(int.Parse)
            .ToArray();

        Lake lake = new Lake(stones);

        Console.WriteLine(string.Join(", ", lake));
    }
}