using System;
using System.Text;
using System.Linq;
using System.Reflection;

public class Spy
{
    public string StealFieldInfo(string className, params string[] fieldNames)
    {
        Type classType = this.GetType(className);
        object classInstance = Activator.CreateInstance(classType);

        StringBuilder result = new StringBuilder();

        result.AppendLine($"Class under investigation: {className}");

        FieldInfo[] fields = classType.GetFields(
            BindingFlags.Instance | BindingFlags.Static |
            BindingFlags.NonPublic | BindingFlags.Public);

        foreach (FieldInfo field in fields
            .Where(f => fieldNames.Contains(f.Name)))
        {
            result.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
        }

        //foreach (string fieldName in fieldNames)
        //{
        //    FieldInfo field = classType.GetField(fieldName,
        //        BindingFlags.Instance | BindingFlags.Static |
        //        BindingFlags.NonPublic | BindingFlags.Public);

        //    result.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
        //}

        return result.ToString().TrimEnd();
    }
    
    private Type GetType(string className) => Type.GetType(className);

    public string AnalyzeAcessModifiers(string className)
    {
        Type classType = Type.GetType(className);

        FieldInfo[] invalidFields = classType.GetFields(
            BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
        MethodInfo[] invalidGetters = classType.GetMethods(
            BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static)
            .Where(m => m.Name.StartsWith("get_"))
            .ToArray();
        MethodInfo[] invalidSetters = classType.GetMethods(
            BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static)
            .Where(m => m.Name.StartsWith("set_"))
            .ToArray();

        StringBuilder result = new StringBuilder();

        foreach (FieldInfo field in invalidFields)
        {
            result.AppendLine($"{field.Name} must be private!");
        }

        foreach (MethodInfo method in invalidGetters)
        {
            result.AppendLine($"{method.Name} have to be public!");
        }

        foreach (MethodInfo method in invalidSetters)
        {
            result.AppendLine($"{method.Name} have to be private!");
        }

        return result.ToString().TrimEnd();
    }

    public string RevealPrivateMethods(string className)
    {
        Type classType = this.GetType(className);
        StringBuilder result = new StringBuilder();

        result.AppendLine($"All Private Methods of Class: {className}");
        result.AppendLine($"Base Class: {classType.BaseType.Name}");

        MethodInfo[] nonPublicMethods = classType.GetMethods(
            BindingFlags.Instance | BindingFlags.NonPublic);
        
        foreach (MethodInfo method in nonPublicMethods)
        {
            result.AppendLine(method.Name);
        }

        return result.ToString().TrimEnd();
    }

    public string CollectGettersAndSetters(string className)
    {
        Type classType = this.GetType(className);

        MethodInfo[] methods = classType.GetMethods(
            BindingFlags.Instance | BindingFlags.Static | 
            BindingFlags.NonPublic | BindingFlags.Public);

        MethodInfo[] getters = methods.Where(m => m.Name.StartsWith("get_")).ToArray();
        MethodInfo[] setters = methods.Where(m => m.Name.StartsWith("set_")).ToArray();

        StringBuilder result = new StringBuilder();

        foreach (MethodInfo getter in getters)
        {
            result.AppendLine($"{getter.Name} will return {getter.ReturnType}");
        }

        foreach (MethodInfo setter in setters)
        {
            result.AppendLine($"{setter.Name} will set field of {setter.GetParameters().First().ParameterType}");
        }

        return result.ToString().TrimEnd();
    }
}