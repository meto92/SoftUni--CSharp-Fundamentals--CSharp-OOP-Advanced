using System;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections.Generic;

public class HarvestingFieldsTest
{
    private static IEnumerable<FieldInfo> GetPrivateFields(Type type)
    {
        return type.GetFields(
            BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic)
            .Where(f => f.IsPrivate);
    }

    private static IEnumerable<FieldInfo> GetProtectedFields(Type type)
    {
        return type.GetFields(
            BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic)
            .Where(f => f.IsFamily);
    }

    private static IEnumerable<FieldInfo> GetPublicFields(Type type)
    {
        return type.GetFields(
            BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
    }

    private static IEnumerable<FieldInfo> GetAllFields(Type type)
    {
        return type.GetFields(
            BindingFlags.Instance | BindingFlags.Static |
            BindingFlags.NonPublic | BindingFlags.Public);
    }

    private static void PrintFields(IEnumerable<FieldInfo> fields)
    {
        StringBuilder result = new StringBuilder();

        foreach (FieldInfo field in fields)
        {
            string accessModifier = "private";

            if (field.IsFamily)
            {
                accessModifier = "protected";
            }
            else if (field.IsPublic)
            {
                accessModifier = "public";
            }

            result.AppendLine($"{accessModifier} {field.FieldType.Name} {field.Name}");
        }

        Console.WriteLine(result.ToString().TrimEnd());
    }

    public static void Main()
    {
        Type type = typeof(HarvestingFields);

        string input = null;

        while ((input = Console.ReadLine()) != "HARVEST")
        {
            IEnumerable<FieldInfo> fields = null;

            switch (input)
            {
                case "private":
                    fields = GetPrivateFields(type);
                    break;
                case "protected":
                    fields = GetProtectedFields(type);
                    break;
                case "public":
                    fields = GetPublicFields(type);
                    break;
                case "all":
                    fields = GetAllFields(type);
                    break;
            }

            PrintFields(fields);
        }
    }    
}