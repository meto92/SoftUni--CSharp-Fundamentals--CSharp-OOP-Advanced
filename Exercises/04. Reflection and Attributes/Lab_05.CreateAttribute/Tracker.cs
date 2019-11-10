using System;
using System.Reflection;
using System.Collections.Generic;

public class Tracker
{
    public void PrintMethodsByAuthor()
    {
        Type classType = typeof(Startup);

        MethodInfo[] methods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);

        foreach (MethodInfo method in methods)
        {
            IEnumerable<Attribute> attributes = method.GetCustomAttributes();
            
            foreach (Attribute attribute in attributes)
            {
                SoftUniAttribute softUniAttribute = attribute as SoftUniAttribute;

                if (softUniAttribute == null)
                {
                    continue;
                }

                Console.WriteLine($"{method.Name} is written by {softUniAttribute.Name}");
            }
        }
    }
}