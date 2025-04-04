using System.Diagnostics;

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

  public static void AllTests(string folderPath, TestedMethod etalonMethod, TestedMethod studentMethod, string sortName)
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
          bool result = TestSorting(etalonMethod, studentMethod, testArray, out long studentTime);
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
