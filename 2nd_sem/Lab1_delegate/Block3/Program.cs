using System;

internal class Program
{
  public delegate double UnitOfSeries(int n);

  static void Main(string[] args)
  {
    Console.Write("Enter precision for the calculated series: ");
    int precision = Convert.ToInt32(Console.ReadLine());

    UnitOfSeries series1 = n => 1.0 / Math.Pow(2, n);
    UnitOfSeries series2 = n => 1.0 / FastFactorial(n + 1);
    UnitOfSeries series3 = n => 1.0 * Math.Pow(-1, n + 1) / Math.Pow(2, n);

    Console.WriteLine($"Series 1: {CalculateValueOfSeries(series1, precision)}");
    Console.WriteLine($"Series 2: {CalculateValueOfSeries(series2, precision)}");
    Console.WriteLine($"Series 3: {CalculateValueOfSeries(series3, precision)}");

  }

  static double CalculateValueOfSeries(UnitOfSeries unit, int precision)
  {
    double value = 0.0;
    for (int i = 0; i <= precision; ++i)
    {
      value += unit(i);
    }
    return value;
  }
  static double FastFactorial(int n)
  {
    double value = 1.0;
    for (int i = 2; i <= n; i++)
    {
      value *= i;
    }
    return value;
  }

}
