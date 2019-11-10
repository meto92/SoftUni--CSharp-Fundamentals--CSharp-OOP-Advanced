public class MultiplicationStrategy : CalculationStrategy
{
    public override int Calculate(int firstOperand, int secondOperand)
    {
        return firstOperand * secondOperand;
    }
}