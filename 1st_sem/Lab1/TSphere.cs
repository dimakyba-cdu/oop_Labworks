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

    public override double GetArea()
    {
      return 4 * Math.PI * Math.Pow(Radius, 2);
    }

    public int CompareTo(TSphere other)
    {
      if (this.GetVolume() > other.GetVolume())
        return 1;
      else if (this.GetVolume() < other.GetVolume())
        return -1;
      else
        return 0;
    }

    public static TSphere operator +(TSphere a, TSphere b)
    {
      return new TSphere(a.Radius + b.Radius);
    }

    public static TSphere operator -(TSphere a, TSphere b)
    {
      return new TSphere(Math.Abs(a.Radius - b.Radius));
    }

    public static TSphere operator *(TSphere a, double scalar)
    {
      return new TSphere(a.Radius * scalar);
    }

    public static TSphere operator *(double scalar, TSphere a)
    {
      return new TSphere(a.Radius * scalar);
    }

    public override bool Equals(object obj)
    {
      if (obj == null || GetType() != obj.GetType())
        return false;

      TSphere other = (TSphere)obj;
      return Radius == other.Radius;
    }

    public override int GetHashCode()
    {
      return Radius.GetHashCode();
    }
  }
}
