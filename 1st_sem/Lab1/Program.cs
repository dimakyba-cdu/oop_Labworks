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
      do
      {
        Console.WriteLine("1. Arithmetic Progression");
        Console.WriteLine("2. Circle");
        Console.WriteLine("3. Sphere");
        Console.WriteLine("4. HashSet and Equals");
        Console.WriteLine("0. Exit");
        Console.WriteLine("Enter your choice: ");
        choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
          case 1:
            Console.WriteLine("Blank constructor");
            ArithmeticProgression ap1 = new ArithmeticProgression();
            ap1.Output();
            Console.WriteLine("\n-------------"); ;
            Console.WriteLine("Value constructor");
            ap1 = new ArithmeticProgression(1.0, 4, 5);
            ap1.Amount = 5;
            ap1.Output();
            Console.WriteLine("-------------");

            Console.WriteLine("Indexator demonstration:");
            Console.WriteLine(ap1[3]);
            Console.WriteLine(ap1[2]);
            // Console.WriteLine(ap1[5]); custom exception
            Console.WriteLine("-------------");

            Console.WriteLine("Input/Output demonstration:");
            ArithmeticProgression ap2 = new();
            ap2.Input();
            ap2.Output();
            Console.WriteLine("Sum of the arithmetic progression: " + ap2.SumOfSequence());
            Console.WriteLine("-------------");
            break;
          case 2:
            TCircle circle5435 = new();
            circle5435.Input();
            circle5435.Output();

            Console.WriteLine(circle5435.GetArea());
            Console.WriteLine();
            Console.WriteLine("Exploring circle:");
            TCircle circle = new(radius);
            Console.WriteLine(circle);
            Console.WriteLine(circle.GetArea());
            Console.WriteLine(circle.GetCircumference());
            Console.WriteLine(circle.Radius);
            Console.WriteLine(circle.GetSectorArea(angle));

            Console.WriteLine("-------------");
            Console.WriteLine("Exploring copyCircle:");
            TCircle copyCircle = new(circle);
            Console.WriteLine(copyCircle);
            Console.WriteLine(copyCircle.GetArea());
            Console.WriteLine(copyCircle.GetCircumference());
            Console.WriteLine(copyCircle.Radius);
            Console.WriteLine();

            Console.WriteLine("Exploring comparison:");
            Console.WriteLine(circle.CompareTo(copyCircle));

            Console.WriteLine();
            Console.WriteLine("Exploring operators:");
            Console.WriteLine(circle + copyCircle);
            Console.WriteLine(circle - copyCircle);
            Console.WriteLine(circle * 6);
            Console.WriteLine(6 * circle);
            Console.WriteLine("-------------\n");
            break;
          case 3:
            Console.WriteLine();
            Console.WriteLine("Exploring sphere:");
            TSphere sphere = new(radius);
            Console.WriteLine(sphere.GetArea());
            Console.WriteLine(sphere.GetVolume());
            Console.WriteLine(sphere.Radius);

            Console.WriteLine("-------------");
            Console.WriteLine("Exploring copySphere:");
            TSphere copySphere = new(sphere * 2);
            Console.WriteLine(copySphere.GetArea());
            Console.WriteLine(copySphere.GetVolume());
            Console.WriteLine(copySphere.Radius);
            Console.WriteLine();
            Console.WriteLine("Exploring comparison:");
            Console.WriteLine(sphere.CompareTo(copySphere));
            Console.WriteLine("Exploring operators:");
            Console.WriteLine(sphere + copySphere);
            Console.WriteLine(sphere - copySphere);
            Console.WriteLine(sphere * 6);
            Console.WriteLine(6 * sphere);
            Console.WriteLine("-------------\n");
            break;

          case 4:
            Console.WriteLine("Exploring HashSet and Equals behaviour for TCircle:");
            HashSet<TCircle> circles = new();
            TCircle circle1 = new(5);
            circles.Add(circle1);
            TCircle circle2 = new(5);
            circles.Add(circle2);
            Console.WriteLine(circles.Count);

            Console.WriteLine("Exploring HashSet and Equals behaviour for TSphere:");
            HashSet<TSphere> spheres = new();
            TSphere sphere1 = new(5);
            spheres.Add(sphere1);
            TSphere sphere2 = new(5);
            spheres.Add(sphere2);
            Console.WriteLine(spheres.Count);
            Console.WriteLine("-------------\n");
            break;

          default:
            break;
        }

      } while (choice != 0);

    }
  }
}
