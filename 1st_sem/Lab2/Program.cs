namespace Lab2
{
  internal class Program
  {
    static void Main(string[] args)
    {
      double[,] array = { { 1, 2 }, { 3, 4 } };
      MyMatrix matrix1 = new MyMatrix(array);
      Console.WriteLine("Matrix 1:");
      Console.WriteLine(matrix1);

      MyMatrix matrixCopy = new MyMatrix(matrix1);
      Console.WriteLine("\nMatrix Copy:");
      Console.WriteLine(matrixCopy);

      string matrixData = "5 6\n7 8";
      MyMatrix matrix2 = new MyMatrix(matrixData);
      Console.WriteLine("\nMatrix 2:");
      Console.WriteLine(matrix2);

      MyMatrix sumMatrix = matrix1 + matrix2;
      Console.WriteLine("\nSum of Matrix 1 and Matrix 2:");
      Console.WriteLine(sumMatrix);

      MyMatrix multipliedMatrix = matrix1 * matrix2;
      Console.WriteLine("\nProduct of Matrix 1 and Matrix 2:");
      Console.WriteLine(multipliedMatrix);

      MyMatrix transposedCopy = matrix1.GetTransponedCopy();
      Console.WriteLine("\nTransposed Copy of Matrix 1:");
      Console.WriteLine(transposedCopy);

      matrix1.TransponeMe();
      Console.WriteLine("\nMatrix 1 after Transpose:");
      Console.WriteLine(matrix1);

      try
      {
        double determinant = matrix1.CalcDeterminant();
        Console.WriteLine($"\nDeterminant of Matrix 1: {determinant}");
      }
      catch (InvalidOperationException ex)
      {
        Console.WriteLine($"Error calculating determinant: {ex.Message}");
      }

      try
      {
        double[,] arraySmall = { { 1 } };
        MyMatrix smallMatrix = new MyMatrix(arraySmall);
        var invalidSum = matrix1 + smallMatrix;
      }
      catch (InvalidOperationException ex)
      {
        Console.WriteLine($"\nError adding matrices of different sizes: {ex.Message}");
      }
    }
  }

}
