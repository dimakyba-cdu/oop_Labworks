using System;

namespace Lab1
{
  class Program
  {
    static void Main(string[] args)
    {
      ArithmeticProgression ap1 = new ArithmeticProgression(1.0, 4, 5);
      Console.WriteLine(ap1[3]);
      Console.WriteLine(ap1[7]);
      ArithmeticProgression ap2 = new();
      ap2.Input();
      ap2.Output();
      Console.WriteLine(ap2.SumOfSequence());

    }
  }
}
