using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

public class Program
{
  public static void Main()
  {
    string folderPath = "test_cases";

    while (true)
    {
      Console.WriteLine("\nMenu:");
      Console.WriteLine("1. Generate new test data");
      Console.WriteLine("2. Test Selection Sort");
      Console.WriteLine("3. Test Shaker Sort");
      Console.WriteLine("4. Exit");
      Console.Write("Choose an option: ");
      string choice = Console.ReadLine();

      switch (choice)
      {
        case "1":
          GenerateNewData(folderPath);
          break;
        case "2":
          VerifyMethod(folderPath, SortingAlgorithms.SelectionSort, SortingAlgorithms.StudentSelectionSort, "Selection Sort");
          break;
        case "3":
          VerifyMethod(folderPath, SortingAlgorithms.ShakerSort, SortingAlgorithms.StudentShakerSort, "Shaker Sort");
          break;
        case "4":
          return;
        default:
          Console.WriteLine("Invalid option. Please try again.");
          break;
      }
    }
  }

  private static void GenerateNewData(string folderPath)
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

        TestDataGenerator.GenerateTestData(folderPath, n, k);
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

  private static void VerifyMethod(string folderPath, SortingTester.TestedMethod etalonMethod, SortingTester.TestedMethod studentMethod, string sortName)
  {
    string[] testCaseFiles = Directory.EnumerateFiles(folderPath, "*.txt").ToArray();
    int passedTests = 0;

    for (int i = 0; i < testCaseFiles.Length; i++)
    {
      string filePath = testCaseFiles[i];
      if (File.Exists(filePath))
      {
        int[] testArray = File.ReadAllText(filePath)
                              .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                              .Select(int.Parse)
                              .ToArray();

        Console.WriteLine($"\n--- TestCase #{i + 1} ---");

        try
        {
          bool result = SortingTester.TestSorting(etalonMethod, studentMethod, testArray, out long studentTime);
          if (result)
          {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"OK  - Elapsed time: {studentTime} ms");
            Console.ResetColor();
            passedTests++;
          }
          else
          {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("WA");
            Console.ResetColor();
          }
        }
        catch (TimeoutException)
        {
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine("TL");
          Console.ResetColor();
        }
        catch (Exception ex)
        {
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine($"CE: {ex.Message} ");
          Console.ResetColor();
        }
      }
      else
      {
        Console.WriteLine($"Test case file #{i + 1} not found.");
      }
    }

    int totalTests = testCaseFiles.Length;
    int score = (int)Math.Round((double)passedTests / totalTests * 100);
    Console.WriteLine($"\nScore: {score}/100");
  }
}

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
}

public static class SortingTester
{
  public delegate void TestedMethod(int[] array);

  public static bool TestSorting(TestedMethod etalonMethod, TestedMethod studentMethod, int[] array, out long studentTime)
  {
    int[] etalonArray = (int[])array.Clone();
    int[] studentArray = (int[])array.Clone();

    Stopwatch stopwatch = new Stopwatch();

    stopwatch.Start();
    etalonMethod(etalonArray);
    stopwatch.Stop();
    long etalonTime = stopwatch.ElapsedMilliseconds;

    stopwatch.Reset();
    stopwatch.Start();
    try
    {
      studentMethod(studentArray);
    }
    catch (Exception)
    {
      Console.WriteLine("Student method crashed.");
      studentTime = 0;
      return false;
    }
    stopwatch.Stop();
    studentTime = stopwatch.ElapsedMilliseconds;

    bool isCorrect = etalonArray.SequenceEqual(studentArray);
    bool isTimeComparable = Math.Max(0, etalonTime / 5 - 200) <= studentTime && studentTime <= 5 * etalonTime + 200;

    return isCorrect && isTimeComparable;
  }
}

public static partial class SortingAlgorithms
{
  public static void SelectionSort(int[] array)
  {
    int n = array.Length;
    for (int i = 0; i < n - 1; i++)
    {
      int minIndex = i;
      for (int j = i + 1; j < n; j++)
      {
        if (array[j] < array[minIndex])
        {
          minIndex = j;
        }
      }
      int temp = array[minIndex];
      array[minIndex] = array[i];
      array[i] = temp;
    }
  }

  public static void ShakerSort(int[] array)
  {
    int n = array.Length;
    bool swapped;
    do
    {
      swapped = false;
      for (int i = 0; i < n - 2; i++)
      {
        if (array[i] > array[i + 1])
        {
          int temp = array[i];
          array[i] = array[i + 1];
          array[i + 1] = temp;
          swapped = true;
        }
      }
      if (!swapped) break;
      swapped = false;
      for (int i = n - 2; i >= 0; i--)
      {
        if (array[i] >= array[i + 1])
        {
          int temp = array[i];
          array[i] = array[i + 1];
          array[i + 1] = temp;
          swapped = true;
        }
      }
    } while (swapped);
  }



  public static void StudentSelectionSort(int[] array)
  {
    // Student implementation
  }

  public static void StudentShakerSort(int[] array)
  {
    int left = 0;
    int right = array.Length - 1;
    while (left <= right)
    {
      for (int i = left; i < right; i++)
      {
        if (array[i] > array[i + 1])
        {
          int temp = array[i];
          array[i] = array[i + 1];
          array[i + 1] = temp;
        }
      }
      right--;
      for (int i = right; i > left; i--)
      {
        if (array[i] < array[i - 1])
        {
          int temp = array[i];
          array[i] = array[i - 1];
          array[i - 1] = temp;
        }
      }
      left++;
    }
  }
}
