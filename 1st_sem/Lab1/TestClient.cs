using System;

namespace Lab1
{
  class TestClient
  {
    static void Main(string[] args)
    {
      ArithmeticProgression ap1 = new ArithmeticProgression(1.0, 4, 5);
      Console.WriteLine(ap1[3]);
      Console.WriteLine(ap1[2]);
      ArithmeticProgression ap2 = new();
      ap2.Input();
      ap2.Output();
      Console.WriteLine(ap2.SumOfSequence());
      Console.WriteLine("-------------");

      int radius = 5;
      TCircle circle = new(radius);
      Console.WriteLine(circle.GetArea());
      Console.WriteLine(circle.GetCircumference());
      Console.WriteLine(circle.Radius);
      Console.WriteLine("-------------");
      TCircle copyCircle = new(circle);
      Console.WriteLine(copyCircle.GetArea());
      Console.WriteLine(copyCircle.GetCircumference());
      Console.WriteLine(copyCircle.Radius);


      Console.WriteLine("-------------");
      TSphere sphere = new(radius);
      Console.WriteLine(sphere.GetArea());
      Console.WriteLine(sphere.GetVolume());
      Console.WriteLine(sphere.Radius);
      Console.WriteLine("-------------");
      TSphere copySphere = new(sphere);
      Console.WriteLine(copySphere.GetArea());
      Console.WriteLine(copySphere.GetVolume());
      Console.WriteLine(copySphere.Radius);



    }
  }
}
