using System;
using System.IO;

namespace RegExLab_A
{
  class Program
  {
    static String searchPatt = "(a{1,}b{2,}c{1,})";
    static String replacePatt = "QQQ";

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
