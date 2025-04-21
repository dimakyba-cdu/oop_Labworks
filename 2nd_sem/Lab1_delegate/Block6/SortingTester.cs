using System;
using System.Diagnostics;
using System.Linq;

public static class SortingTester
{
  private static readonly string _folderPath = "TestArrays";
  public delegate void SortMethod(int[] array);
  public delegate bool TimeVerifier(long etalonTime, long studentTime);

  public static bool TestSorting(SortMethod etalon, SortMethod student, int[] input, out long studentTime, TimeVerifier timeVerifier = null)
  {
    int[] etalonCopy = (int[])input.Clone();
    int[] studentCopy = (int[])input.Clone();

    long etalonTime = MeasureTime(etalon, etalonCopy);
    studentTime = MeasureTime(student, studentCopy);

    bool correct = etalonCopy.SequenceEqual(studentCopy);

    if (timeVerifier == null)
    {
      timeVerifier = (et, st) => st <= et * 2 + 50;
    }

    return correct && timeVerifier(etalonTime, studentTime);
  }

  private static long MeasureTime(SortMethod method, int[] array)
  {
    Stopwatch sw = new Stopwatch();
    sw.Start();
    try
    {
      method(array);
    }
    catch { return long.MaxValue; }
    sw.Stop();
    return sw.ElapsedMilliseconds;
  }

  public static void VerifyMethod(SortMethod etalon, SortMethod student)
  {
    TimeVerifier timeVerifier = (etalonTime, studentTime) => studentTime < (etalonTime * 1.5);

    string[] files = Directory.GetFiles(_folderPath, "*.txt");
    int passed = 0;


    for (int i = 0; i < files.Length; i++)
    {
      string content = File.ReadAllText(files[i]);
      int[] input = content.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

      Console.WriteLine($"\n--- Тест #{i + 1} ---");

      bool result = TestSorting(etalon, student, input, out long studentTime, timeVerifier);

      if (result)
      {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"OK  | Час: {studentTime} мс");
        passed++;
      }
      else
      {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"WA | Час: {studentTime} мс");
      }
      Console.ResetColor();
    }

    int score = (int)Math.Round((double)passed / files.Length * 100);
    Console.WriteLine($"\nПідсумок: {score}/100");
  }
}
