using System;
using System.IO;

namespace RegExLab_A
{
  class Program
  {
    static String searchPatt = @"\\circle\{\((\d+),(\d+)\)";
    static String replacePatt = @"\circle{($2,$1)";

    static void Main(string[] args)
    {
      String str = Console.ReadLine();
      while (str != null)
      {
        String newStr = System.Text.RegularExpressions.Regex.Replace(str, searchPatt, replacePatt);
        Console.WriteLine(newStr);
        str = Console.ReadLine();
      }
    }
  }
}
