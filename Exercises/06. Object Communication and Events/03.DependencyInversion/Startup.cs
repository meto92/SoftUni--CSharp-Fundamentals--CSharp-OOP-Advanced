using System;

public class Startup
{
    public static void Main()
    {
        PrimitiveCalculator primitiveCalculator = new PrimitiveCalculator();

        string input = null;

        while ((input = Console.ReadLine()) != "End")
        {
            string[] inputParams = input.Split();

            if (inputParams[0] == "mode")
            {
                primitiveCalculator.ChangeStrategy(inputParams[1][0]);
            }
            else
            {
                int firstOperand = int.Parse(inputParams[0]);
                int secondOperand = int.Parse(inputParams[1]);

                int result = primitiveCalculator.PerformCalculation(firstOperand, secondOperand);

                Console.WriteLine(result);
            }
        }
    }
}