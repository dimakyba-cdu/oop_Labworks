using System;
using System.IO;

namespace RegExLab_A
{
  class Program
  {
    static String searchPatt = @"\\texttt\{([a-zA-Z]+|[0-9]+)\}";
    static String replacePatt = @"\begin{ttfamily}$1\end{ttfamily}";

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
