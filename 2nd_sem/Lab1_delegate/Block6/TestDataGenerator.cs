using System;
using System.IO;
using System.Linq;

public static class TestDataGenerator
{
  public static void GenerateTestData(string folderPath, int n, int k)
  {
    if (!Directory.Exists(folderPath))
    {
      Directory.CreateDirectory(folderPath);
    }

    Random rand = new Random();

    for (int i = 0; i < k; i++)
    {
      int[] array = new int[n];
      for (int j = 0; j < n; j++)
      {
        array[j] = rand.Next(1000);
      }

      string filePath = Path.Combine(folderPath, $"test_case_{i + 1}.txt");
      File.WriteAllText(filePath, string.Join(" ", array));
    }
  }
  public static void WriteData(string folderPath)
  {
    Console.Write("Enter the number of elements (n): ");
    if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
    {
      Console.Write("Enter the number of test cases (k): ");
      if (int.TryParse(Console.ReadLine(), out int k) && k > 0)
      {
        // Delete existing files in the folder
        if (Directory.Exists(folderPath))
        {
          string[] existingFiles = Directory.GetFiles(folderPath);
          foreach (string file in existingFiles)
          {
            File.Delete(file);
          }
        }

        GenerateTestData(folderPath, n, k);
        Console.WriteLine($"Generated {k} test cases with {n} elements each.");
      }
      else
      {
        Console.WriteLine("Invalid number of test cases.");
      }
    }
    else
    {
      Console.WriteLine("Invalid number of elements.");
    }
  }

}
