using System;

internal class Program
{
  static void Main(string[] args)
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
          TestDataGenerator.WriteData(folderPath);
          break;
        case "2":
          SortingTester.AllTests(folderPath, SortingAlgorithms.SelectionSort, SortingAlgorithms.StudentSelectionSort, "Selection Sort");
          break;
        case "3":
          SortingTester.AllTests(folderPath, SortingAlgorithms.ShakerSort, SortingAlgorithms.StudentShakerSort, "Shaker Sort");
          break;
        case "4":
          return;
        default:
          Console.WriteLine("Invalid option. Please try again.");
          break;
      }
    }
  }
}
