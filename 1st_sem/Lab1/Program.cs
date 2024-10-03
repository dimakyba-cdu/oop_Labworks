using System;

class Program
{
  static void Main(string[] args)
  {
    Console.WriteLine("Hello, world!");
    ArithmeticProgression ap = new ArithmeticProgression(1, 4, 5);
    Console.WriteLine(ap[2]);
    Console.WriteLine(ap.SumOfSequence());
  }
}
