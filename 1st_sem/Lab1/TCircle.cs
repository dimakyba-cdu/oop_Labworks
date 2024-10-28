namespace Lab1
{
  class TCircle
  {
    private double radius;

    public TCircle()
    {
      radius = 0.0;
    }

    public TCircle(double radius)
    {
      this.radius = radius;
    }

    public TCircle(TCircle other)
    {
      this.radius = other.radius;
    }

    public double Radius
    {
      get { return radius; }
      set
      {
        if (value >= 0)
          radius = value;
        else
          throw new ArgumentOutOfRangeException(nameof(value), "Radius cannot be negative");
      }
    }

    public override string ToString()
    {
      return $"Circle with a radius: {radius}";
    }

    public void Input()
    {
      Console.Write("Enter the radius of the circle: ");
      radius = Convert.ToDouble(Console.ReadLine());
    }

    public void Output()
    {
      Console.WriteLine(ToString());
    }

    public virtual double GetArea()
    {
      return Math.PI * radius * radius;
    }

    public double GetSectorArea(double angle)
    {
      return (angle / 360.0) * GetArea();
    }

    public double GetCircumference()
    {
      return 2 * Math.PI * radius;
    }

    public int CompareTo(TCircle other)
    {
      if (this.radius > other.radius)
        return 1;
      else if (this.radius < other.radius)
        return -1;
      else
        return 0;
    }

    public static TCircle operator +(TCircle a, TCircle b)
    {
      return new TCircle(a.radius + b.radius);
    }

    public static TCircle operator -(TCircle a, TCircle b)
    {
      return new TCircle(Math.Abs(a.radius - b.radius));
    }

    public static TCircle operator *(TCircle a, double scalar)
    {
      return new TCircle(a.radius * scalar);
    }

    public static TCircle operator *(double scalar, TCircle a)
    {
      return new TCircle(a.radius * scalar);
    }

    public override bool Equals(object obj)
    {
      if (obj == null || GetType() != obj.GetType())
        return false;

      TCircle other = (TCircle)obj;
      return radius == other.radius;
    }

    public override int GetHashCode()
    {
      return radius.GetHashCode();
    }
  }
}
