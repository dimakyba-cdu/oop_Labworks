namespace Lab2
{

  using System;

  public partial class MyMatrix
  {
    public static MyMatrix operator +(MyMatrix a, MyMatrix b)
    {
      if (a.Height != b.Height || a.Width != b.Width)
        throw new InvalidOperationException("Matrices must have the same dimensions for addition.");

      var result = new MyMatrix(new double[a.Height, a.Width]);
      for (int i = 0; i < a.Height; i++)
        for (int j = 0; j < a.Width; j++)
          result[i, j] = a[i, j] + b[i, j];

      return result;
    }

    public static MyMatrix operator *(MyMatrix a, MyMatrix b)
    {
      if (a.Width != b.Height)
        throw new InvalidOperationException("The number of columns in the first matrix must equal the number of rows in the second matrix.");

      var result = new MyMatrix(new double[a.Height, b.Width]);
      for (int i = 0; i < a.Height; i++)
        for (int j = 0; j < b.Width; j++)
          for (int k = 0; k < a.Width; k++)
            result[i, j] += a[i, k] * b[k, j];

      return result;
    }

    private double[,] GetTransponedArray()
    {
      var transposed = new double[Width, Height];
      for (int i = 0; i < Height; i++)
        for (int j = 0; j < Width; j++)
          transposed[j, i] = _matrix[i, j];
      return transposed;
    }

    public MyMatrix GetTransponedCopy()
    {
      return new MyMatrix(GetTransponedArray());
    }

    public void TransponeMe()
    {
      _matrix = GetTransponedArray();
    }

    private double? _cachedDeterminant = null;

    public double CalcDeterminant()
    {
      if (Height != Width)
        throw new InvalidOperationException("Determinant can only be calculated for square matrices.");

      if (_cachedDeterminant.HasValue)
        return _cachedDeterminant.Value;

      _cachedDeterminant = CalculateDeterminant((double[,])_matrix.Clone());
      return _cachedDeterminant.Value;
    }

    private double CalculateDeterminant(double[,] matrix)
    {
      int n = matrix.GetLength(0);
      if (n == 1) return matrix[0, 0];
      if (n == 2) return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];

      double det = 0;
      for (int p = 0; p < n; p++)
      {
        double[,] minor = new double[n - 1, n - 1];
        for (int i = 1; i < n; i++)
          for (int j = 0, col = 0; j < n; j++)
            if (j != p) minor[i - 1, col++] = matrix[i, j];

        det += matrix[0, p] * CalculateDeterminant(minor) * (p % 2 == 0 ? 1 : -1);
      }
      return det;
    }
  }

}
