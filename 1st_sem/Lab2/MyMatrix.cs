namespace Lab2
{

  public partial class MyMatrix
  {
    private double[,] _matrix;

    public MyMatrix(MyMatrix other)
    {
      _matrix = (double[,])other._matrix.Clone();
    }

    public MyMatrix(double[,] array)
    {
      if (!IsRectangular(array)) throw new ArgumentException("Array must be rectangular.");
      _matrix = (double[,])array.Clone();
    }

    public MyMatrix(double[][] jaggedArray)
    {
      if (!IsRectangular(jaggedArray)) throw new ArgumentException("Jagged array must be rectangular.");
      int rows = jaggedArray.Length;
      int cols = jaggedArray[0].Length;
      _matrix = new double[rows, cols];
      for (int i = 0; i < rows; i++)
        for (int j = 0; j < cols; j++)
          _matrix[i, j] = jaggedArray[i][j];
    }

    public MyMatrix(string[] rows)
    {
      var parsedRows = rows.Select(row => row.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray()).ToArray();
      if (!IsRectangular(parsedRows)) throw new ArgumentException("Rows must form a rectangular matrix.");
      int rowCount = parsedRows.Length;
      int colCount = parsedRows[0].Length;
      _matrix = new double[rowCount, colCount];
      for (int i = 0; i < rowCount; i++)
        for (int j = 0; j < colCount; j++)
          _matrix[i, j] = parsedRows[i][j];
    }

    public MyMatrix(string data)
    {
      var rows = data.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
      var parsedRows = rows.Select(row => row.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray()).ToArray();
      if (!IsRectangular(parsedRows)) throw new ArgumentException("Data must form a rectangular matrix.");
      int rowCount = parsedRows.Length;
      int colCount = parsedRows[0].Length;
      _matrix = new double[rowCount, colCount];
      for (int i = 0; i < rowCount; i++)
        for (int j = 0; j < colCount; j++)
          _matrix[i, j] = parsedRows[i][j];
    }

    public int Height => _matrix.GetLength(0);
    public int Width => _matrix.GetLength(1);

    public int GetHeight() => Height;
    public int GetWidth() => Width;

    public double this[int row, int col]
    {
      get => _matrix[row, col];
      set => _matrix[row, col] = value;
    }

    public double GetElement(int row, int col) => _matrix[row, col];
    public void SetElement(int row, int col, double value) => _matrix[row, col] = value;

    public override string ToString()
    {
      return string.Join("\n", Enumerable.Range(0, Height).Select(i =>
          string.Join("\t", Enumerable.Range(0, Width).Select(j => _matrix[i, j].ToString()))));
    }

    private bool IsRectangular(double[][] array)
    {
      return array.Length > 0 && array.All(row => row.Length == array[0].Length);
    }

    private bool IsRectangular(double[,] array)
    {
      return array != null && array.Length > 0;
    }
  }
}
