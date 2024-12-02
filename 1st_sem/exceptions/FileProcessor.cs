
namespace Exceptions
{
  public class FileProcessor
  {
    public void ProcessFiles(string[] filePaths)
    {
      foreach (var filePath in filePaths)
      {
        try
        {
          if (!File.Exists(filePath))
          {
            File.AppendAllText("no_file.txt", $"{filePath}\n");
            continue;
          }

          var numbers = File.ReadAllLines(filePath)
                            .Select(line => long.Parse(line))
                            .ToArray();

          long product = CalculateProduct(numbers);
          Console.WriteLine($"Добуток чисел із файлу {filePath}: {product}");
        }
        catch (FormatException)
        {
          File.AppendAllText("bad_data.txt", $"{filePath}\n");
        }
        catch (OverflowException)
        {
          File.AppendAllText("overflow.txt", $"{filePath}\n");
        }
        catch (Exception ex)
        {
          Console.WriteLine($"Помилка: {ex.Message}");
        }
      }
    }

    private long CalculateProduct(long[] numbers)
    {
      checked
      {
        return numbers.Aggregate(1L, (acc, x) => acc * x);
      }
    }
  }
}
