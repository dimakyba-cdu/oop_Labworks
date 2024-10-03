using System.Text;

namespace Lab1
{
  class ArithmeticProgression
  {
    private double firstElement;
    private double difference;
    private double amount;

    public double FirstElement
    {
      get { return firstElement; }
      set { firstElement = value; }
    }

    public double Difference
    {
      get { return difference; }
      set { difference = value; }
    }

    public double Amount
    {
      get { return amount; }
      set { amount = value; }
    }

    public ArithmeticProgression(double firstElement, double difference, double amount)
    {
      this.firstElement = firstElement;
      this.difference = difference;
      this.amount = amount;
    }

    public ArithmeticProgression()
    {
      this.firstElement = 0;
      this.difference = 0;
      this.amount = 0;
    }

    public double this[int index]
    {
      get
      {
        try
        {
          if (index < 0 || index >= amount)
          {
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range, but custom exception");
          }

          return firstElement + index * difference;
        }
        catch (ArgumentOutOfRangeException ex)
        {
          Console.WriteLine($"Error: {ex.Message}");
          throw;
        }
      }
    }


    public override string ToString()
    {
      StringBuilder progression = new StringBuilder();

      for (int i = 0; i < amount; i++)
      {
        progression.Append(this[i]);

        if (i < amount - 1)
        {
          progression.Append(", ");
        }
      }

      return $"Arithmetic Progression: {progression}";
    }


    public void Input()
    {
      Console.WriteLine("Enter the first element of the arithmetic progression:");
      FirstElement = double.Parse(Console.ReadLine());

      Console.WriteLine("Enter the difference:");
      Difference = double.Parse(Console.ReadLine());

      Console.WriteLine("Enter the amount of elements:");
      Amount = double.Parse(Console.ReadLine());
    }

    public void Output()
    {
      Console.WriteLine(ToString());
    }


    public double SumOfSequence()
    {
      return (amount * (2 * firstElement + (amount - 1) * difference)) / 2;
    }

  }
}
