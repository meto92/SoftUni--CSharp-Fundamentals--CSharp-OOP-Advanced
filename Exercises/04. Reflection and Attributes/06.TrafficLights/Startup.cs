using System;
using System.Linq;

public class Startup
{  
    public static void Main()
    {
        TrafficLight[] trafficLights = Console.ReadLine()
            .Split()
            .Select(str => Enum.Parse<TrafficLight>(str))
            .ToArray();
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < trafficLights.Length; j++)
            {
                trafficLights[j] = (int) trafficLights[j] + 1 < 3
                    ? trafficLights[j] + 1
                    : TrafficLight.Red;
            }

            Console.WriteLine(string.Join(" ", trafficLights));
        }
    }
}