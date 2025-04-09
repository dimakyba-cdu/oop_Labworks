namespace Lab2
{
  public class ScientificCommand(CalculatorEngine calculator, string operation) : CalculatorCommand(calculator)
  {
    private readonly string operation = operation;

    public override void Execute() => calculator.PerformScientificOperation(operation, out _, out _);
  }
}
