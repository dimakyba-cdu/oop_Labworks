using System;

internal class Program
{
  delegate double F(double x);
  static void Main(string[] args)
  {
    F[] funcs = new F[3];

    F squareRootAbs = x => Math.Sqrt(Math.Abs(x));
    F cube = x => Math.Pow(x, 3) - 1;
    F sine = x => Math.Sin(x * Math.PI / 2);

    funcs[0] = squareRootAbs;
    funcs[1] = cube;
    funcs[2] = sine;

    Console.WriteLine("Format of input: \"F X\" where F is the chosen function and X is the value that we pass to the function:");
    Console.WriteLine("Supported functions: 0 - sqrt(abs(x))");
    Console.WriteLine("                     1 - x^3 - 1");
    Console.WriteLine("                     2 - sin(x * pi/2)");

    while (true)
    {
      try
      {
        double[] input = Array.ConvertAll(Console.ReadLine().Trim().Split(), Convert.ToDouble);

        double choice = input[0];
        double value = input[1];

        F targetFunc = funcs[(int)choice];

        Console.WriteLine(targetFunc(value));

      }
      catch
      {
        Console.WriteLine("Your input is wrong and I terminate the program.");
        break;
      }
    }

  }
}
