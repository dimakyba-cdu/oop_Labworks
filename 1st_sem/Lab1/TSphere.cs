namespace Lab1
{
  class TSphere : TCircle
  {
    public TSphere() : base()
    {
    }

    public TSphere(double radius) : base(radius)
    {
    }

    public TSphere(TSphere other) : base(other)
    {
    }

    public double GetVolume()
    {
      return (4.0 / 3.0) * Math.PI * Math.Pow(Radius, 3);
    }

    public override string ToString()
    {
      return $"Sphere with a radius: {Radius}, volume: {GetVolume()}";
    }

    public double GetArea()
    {
      return 4 * Math.PI * Math.Pow(Radius, 2);
    }
  }

}
