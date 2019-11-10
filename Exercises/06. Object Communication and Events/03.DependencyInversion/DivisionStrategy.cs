using System;

public class DivisionStrategy : CalculationStrategy
{
    public override int Calculate(int firstOperand, int secondOperand)
    {
        if (secondOperand == 0)
        {
            throw new InvalidOperationException();
        }

        return firstOperand / secondOperand;
    }
}