using System;
using System.Numerics;
using Xunit;
using Lab;

namespace Lab.Tests
{
  public class MyFracTests
  {
    [Fact]
    public void Constructor_SimplifiesFraction()
    {
      var frac = new MyFrac(4, 8);
      Assert.Equal(new BigInteger(1), frac.Numerator);
      Assert.Equal(new BigInteger(2), frac.Denominator);
    }

    [Fact]
    public void Constructor_ThrowsDivideByZeroException()
    {
      Assert.Throws<DivideByZeroException>(() => new MyFrac(1, 0));
    }

    [Fact]
    public void Add_WorksCorrectly()
    {
      var frac1 = new MyFrac(1, 3);
      var frac2 = new MyFrac(1, 8);
      var result = frac1.Add(frac2);

      Assert.Equal(new BigInteger(11), result.Numerator);
      Assert.Equal(new BigInteger(24), result.Denominator);
    }

    [Fact]
    public void Subtract_WorksCorrectly()
    {
      var frac1 = new MyFrac(1, 2);
      var frac2 = new MyFrac(1, 3);
      var result = frac1.Subtract(frac2);

      Assert.Equal(new BigInteger(1), result.Numerator);
      Assert.Equal(new BigInteger(6), result.Denominator);
    }

    [Fact]
    public void Multiply_WorksCorrectly()
    {
      var frac1 = new MyFrac(2, 3);
      var frac2 = new MyFrac(3, 4);
      var result = frac1.Multiply(frac2);

      Assert.Equal(new BigInteger(1), result.Numerator);
      Assert.Equal(new BigInteger(2), result.Denominator);
    }

    [Fact]
    public void Divide_WorksCorrectly()
    {
      var frac1 = new MyFrac(2, 3);
      var frac2 = new MyFrac(4, 5);
      var result = frac1.Divide(frac2);

      Assert.Equal(new BigInteger(5), result.Numerator);
      Assert.Equal(new BigInteger(6), result.Denominator);
    }

    [Fact]
    public void Divide_ThrowsDivideByZeroException()
    {
      var frac = new MyFrac(1, 2);
      Assert.Throws<DivideByZeroException>(() => frac.Divide(new MyFrac(0, 1)));
    }

    [Fact]
    public void CompareTo_WorksCorrectly()
    {
      var frac1 = new MyFrac(1, 3);
      var frac2 = new MyFrac(2, 3);
      var frac3 = new MyFrac(1, 3);

      Assert.True(frac1.CompareTo(frac2) < 0);
      Assert.True(frac2.CompareTo(frac1) > 0);
      Assert.True(frac1.CompareTo(frac3) == 0);
    }

    [Fact]
    public void CompareTo_ThrowsArgumentNullException()
    {
      var frac = new MyFrac(1, 2);
      Assert.Throws<ArgumentNullException>(() => frac.CompareTo(null));
    }

    [Fact]
    public void ToString_WorksCorrectly()
    {
      var frac = new MyFrac(1, 2);
      Assert.Equal("1/2", frac.ToString());
    }
  }
}
