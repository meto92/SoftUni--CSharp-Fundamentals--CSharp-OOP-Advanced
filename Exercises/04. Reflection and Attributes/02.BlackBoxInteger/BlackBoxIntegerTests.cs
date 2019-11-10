using System;
using System.Linq;
using System.Reflection;

public class BlackBoxIntegerTests
{
    public static void Main()
    {
        Type classType = typeof(BlackBoxInteger);

        ConstructorInfo emptyConstructor = classType
            .GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic)
            .First(ctor => ctor.GetParameters().Length == 1 &&
                ctor.GetParameters()[0].ParameterType == typeof(int));

        object classInstance = emptyConstructor.Invoke(new object[] { 0 });

        FieldInfo innerValueField = classType.GetField("innerValue",
            BindingFlags.Instance | BindingFlags.NonPublic);

        string input = null;

        while ((input = Console.ReadLine()) != "END")
        {
            string[] commandParams = input.Split('_');

            string methodName = commandParams[0];
            int number = int.Parse(commandParams[1]);

            MethodInfo method = classType.GetMethod(methodName,
                BindingFlags.Instance | BindingFlags.NonPublic);

            method.Invoke(classInstance, new object[] { number });

            Console.WriteLine(innerValueField.GetValue(classInstance));
        }
    }
}