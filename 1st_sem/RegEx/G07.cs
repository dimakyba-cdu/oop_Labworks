using System;
using System.IO;

namespace RegExLab_A
{
  class Program
  {
    static String searchPatt = @"([A-Z][a-zA-Z]*)( +[A-Z][a-zA-Z]*){2,}";
    static String replacePatt = @"""$&""";

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
