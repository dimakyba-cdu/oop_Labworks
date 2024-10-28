using System;

namespace Lab1
{
  internal class TestClient
  {
    static void Main(string[] args)
    {

      const int radius = 5;
      const int angle = 90;

      int choice;
      Console.WriteLine("1. Arithmetic Progression");
      Console.WriteLine("2. Circle");
      Console.WriteLine("3. Sphere");
      Console.WriteLine("Enter your choice: ");
      choice = int.Parse(Console.ReadLine());

      switch (choice)
      {
        case 1:
          ArithmeticProgression ap1 = new ArithmeticProgression();
          ap1.Output();
          ap1 = new ArithmeticProgression(1.0, 4, 5);
          ap1.Amount = 5;
          ap1.Output();
          Console.WriteLine(ap1[3]);
          Console.WriteLine(ap1[2]);
          // Console.WriteLine(ap1[5]);
          Console.WriteLine("-------------");

          ArithmeticProgression ap2 = new();
          ap2.Input();
          ap2.Output();
          Console.WriteLine(ap2.SumOfSequence());
          Console.WriteLine("-------------");
          break;
        case 2:
          Console.WriteLine();
          TCircle circle = new(radius);
          Console.WriteLine(circle);
          Console.WriteLine(circle.GetArea());
          Console.WriteLine(circle.GetCircumference());
          Console.WriteLine(circle.Radius);
          Console.WriteLine(circle.GetSectorArea(angle));

          Console.WriteLine("-------------");

          TCircle copyCircle = new(circle);
          Console.WriteLine(copyCircle);
          Console.WriteLine(copyCircle.GetArea());
          Console.WriteLine(copyCircle.GetCircumference());
          Console.WriteLine(copyCircle.Radius);
          Console.WriteLine();

          Console.WriteLine(circle.CompareTo(copyCircle));

          Console.WriteLine();

          Console.WriteLine(circle + copyCircle);
          Console.WriteLine(circle - copyCircle);
          Console.WriteLine(circle * 6);
          Console.WriteLine(6 * circle);
          break;
        case 3:
          Console.WriteLine();
          Console.WriteLine("-------------");
          TSphere sphere = new(radius);
          Console.WriteLine(sphere.GetArea());
          Console.WriteLine(sphere.GetVolume());
          Console.WriteLine(sphere.Radius);
          Console.WriteLine("-------------");
          TSphere copySphere = new(sphere * 2);
          Console.WriteLine(copySphere.GetArea());
          Console.WriteLine(copySphere.GetVolume());
          Console.WriteLine(copySphere.Radius);
          Console.WriteLine();
          Console.WriteLine(sphere.CompareTo(copySphere));

          Console.WriteLine();

          Console.WriteLine(sphere + copySphere);
          Console.WriteLine(sphere - copySphere);
          Console.WriteLine(sphere * 6);
          Console.WriteLine(6 * sphere);
          break;
        default:
          Console.WriteLine("You chose something else");
          break;
      }
    }
  }
}
