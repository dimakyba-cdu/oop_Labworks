using System;
using System.IO;

namespace RegExLab_A
{
  class Program
  {
    static String searchPatt = "([a-z])([A-Z])";
    static String replacePatt = "_?_${0}_?_";

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
