public class PrimitiveCalculator
{
    private AdditionStrategy additionStrategy;
    private SubtractionStrategy subtractionStrategy;
    private MultiplicationStrategy multiplicationStrategy;
    private DivisionStrategy divisionStrategy;
    private CalculationStrategy calculationStrategy;

    public PrimitiveCalculator()
    {
        this.additionStrategy = new AdditionStrategy();
        this.subtractionStrategy = new SubtractionStrategy();
        this.multiplicationStrategy = new MultiplicationStrategy();
        this.divisionStrategy = new DivisionStrategy();

        this.calculationStrategy = this.additionStrategy;
    }

    public void ChangeStrategy(char @operator)
    {
        switch (@operator)
        {
            case '+':
                this.calculationStrategy = this.additionStrategy;
                break;
            case '-':
                this.calculationStrategy = this.subtractionStrategy;
                break;
            case '*':
                this.calculationStrategy = this.multiplicationStrategy;
                break;
            case '/':
                this.calculationStrategy = this.divisionStrategy;
                break;
        }
    }

    public int PerformCalculation(int firstOperand, int secondOperand)
    {
        return this.calculationStrategy.Calculate(firstOperand, secondOperand);
    }
}