using System;
using Xunit;

namespace Lab.Tests
{
  public class MyComplexTests
  {
    [Fact]
    public void Add_TwoComplexNumbers_ReturnsCorrectResult()
    {
      var complex1 = new MyComplex(1, 2);
      var complex2 = new MyComplex(3, 4);

      var result = complex1.Add(complex2);

      Assert.Equal(new MyComplex(4, 6), result);
    }

    [Fact]
    public void Subtract_TwoComplexNumbers_ReturnsCorrectResult()
    {
      var complex1 = new MyComplex(5, 6);
      var complex2 = new MyComplex(2, 3);

      var result = complex1.Subtract(complex2);

      Assert.Equal(new MyComplex(3, 3), result);
    }

    [Fact]
    public void Multiply_TwoComplexNumbers_ReturnsCorrectResult()
    {
      var complex1 = new MyComplex(1, 2);
      var complex2 = new MyComplex(3, 4);

      var result = complex1.Multiply(complex2);

      Assert.Equal(new MyComplex(-5, 10), result);
    }

    [Fact]
    public void Divide_TwoComplexNumbers_ReturnsCorrectResult()
    {
      var complex1 = new MyComplex(5, 3);
      var complex2 = new MyComplex(1, 2);

      var result = complex1.Divide(complex2);

      Assert.Equal(new MyComplex(2.2, -1.4), result);
    }

    [Fact]
    public void Divide_ByZero_ThrowsDivideByZeroException()
    {
      var complex1 = new MyComplex(5, 6);
      var complex2 = new MyComplex(0, 0);

      var exception = Assert.Throws<DivideByZeroException>(() => complex1.Divide(complex2));
      Assert.Equal("Cannot divide by zero.", exception.Message);
    }

    [Fact]
    public void ToString_ReturnsCorrectStringRepresentation()
    {
      var complex = new MyComplex(3, 4);

      var result = complex.ToString();

      Assert.Equal("3+4i", result);
    }

    [Fact]
    public void Constructor_StringInput_CorrectlyParsesComplexNumber()
    {
      var complex = new MyComplex("3+4i");

      Assert.Equal(3, complex.Real);
      Assert.Equal(4, complex.Imaginary);
    }

    [Fact]
    public void Constructor_InvalidString_ThrowsArgumentException()
    {
      var exception = Assert.Throws<ArgumentException>(() => new MyComplex("invalid"));
      Assert.Equal("Invalid complex number format.", exception.Message);
    }

    [Fact]
    public void Equals_TwoEqualComplexNumbers_ReturnsTrue()
    {
      var complex1 = new MyComplex(1.1, 2.2);
      var complex2 = new MyComplex(1.1, 2.2);

      // Перевірка, що два однакових числа вважаються рівними
      Assert.True(complex1.Equals(complex2));
    }

    [Fact]
    public void Equals_TwoDifferentComplexNumbers_ReturnsFalse()
    {
      var complex1 = new MyComplex(1.1, 2.2);
      var complex2 = new MyComplex(2.3, 4.4);

      Assert.False(complex1.Equals(complex2));
    }

    [Fact]
    public void Equals_ComplexNumberWithNull_ReturnsFalse()
    {
      var complex = new MyComplex(1.1, 2.2);

      Assert.False(complex.Equals(null));
    }

    [Fact]
    public void Equals_ComplexNumberWithDifferentType_ReturnsFalse()
    {
      var complex = new MyComplex(1.1, 2.2);
      var str = "Not a complex number";

      Assert.False(complex.Equals(str));
    }

    [Fact]
    public void GetHashCode_TwoEqualComplexNumbers_ReturnsSameHashCode()
    {
      var complex1 = new MyComplex(1.1, 2.2);
      var complex2 = new MyComplex(1.1, 2.2);

      Assert.Equal(complex1.GetHashCode(), complex2.GetHashCode());
    }

    [Fact]
    public void GetHashCode_TwoDifferentComplexNumbers_ReturnsDifferentHashCode()
    {
      var complex1 = new MyComplex(1.1, 2.2);
      var complex2 = new MyComplex(2.3, 4.4);

      Assert.NotEqual(complex1.GetHashCode(), complex2.GetHashCode());
    }
  }
}
