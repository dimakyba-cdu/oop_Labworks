using static System.Console;


internal class Program
{
  static void Main(string[] args)
  {
    string inputFiles = @"input_files";
    List<string> noFile = new();
    List<string> badData = new();
    List<string> overflow = new();

    List<int> products = new List<int>();

    for (int i = 10; i <= 29; i++)
    {
      string file = Path.Combine(inputFiles, $"{i}.txt");

      try
      {
        StreamReader sr = new StreamReader(file);
        int first = int.Parse(sr.ReadLine());
        int second = int.Parse(sr.ReadLine());
        int product = checked(first * second);
        products.Add(product);
      }
      catch (FileNotFoundException)
      {
        noFile.Add($"{i}.txt");
      }
      catch (FormatException)
      {
        badData.Add($"{i}.txt");
      }
      catch (OverflowException)
      {
        overflow.Add($"{i}.txt");
      }
    }

    try
    {
      long result = products.Select(x => (long)x).Sum() / products.Count;
      WriteLine($"Середнє значення: {result}");
    }
    catch (OverflowException)
    {
      WriteLine("У нас немає середнього значення");
    }
    WriteListToFIle(noFile, "./report_files/no_file.txt");
    WriteListToFIle(badData, "./report_files/bad_data.txt");
    WriteListToFIle(overflow, "./report_files/overflow.txt");

    Console.ReadLine();
  }

  static void WriteListToFIle(List<string> list, string filePath)
  {
    try
    {
      File.WriteAllLines(filePath, list);
      Console.WriteLine($"Файл успішно записано за шляхом: {filePath}");
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Сталася помилка при записі у файл: {ex.Message}");
    }
  }

}
