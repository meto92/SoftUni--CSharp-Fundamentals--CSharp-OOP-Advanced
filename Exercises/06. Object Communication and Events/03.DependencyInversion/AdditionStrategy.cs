public class AdditionStrategy : CalculationStrategy
{
    public override int Calculate(int firstOperand, int secondOperand)
    {
        return firstOperand + secondOperand;
    }
}