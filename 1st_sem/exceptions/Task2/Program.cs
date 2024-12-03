using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Drawing.Imaging;

class Program
{
  static void Main(string[] args)
  {
    Console.WriteLine("Обробка зображень у поточній папці з дзеркальним відображенням.\n");

    string currentDirectory = Directory.GetCurrentDirectory();
    string[] files = Directory.GetFiles(currentDirectory);
    Regex regexExtForImage = new Regex("^.((bmp)|(gif)|(tiff?)|(jpe?g)|(png))$", RegexOptions.IgnoreCase);

    foreach (string file in files)
    {
      try
      {
        if (!regexExtForImage.IsMatch(Path.GetExtension(file)))
          throw new NotSupportedException($"Файл \"{file}\" пропущено: не є графічним.");

        Console.WriteLine($"Обробляємо файл: {Path.GetFileName(file)}");

        Bitmap bitmap;
        try
        {
          bitmap = new Bitmap(file);
        }
        catch
        {
          throw new Exception($"Файл \"{file}\" не вдалося прочитати як зображення.");
        }

        bitmap.RotateFlip(RotateFlipType.RotateNoneFlipY);

        string newFileName = Path.Combine(currentDirectory,
            $"{Path.GetFileNameWithoutExtension(file)}-mirrored.gif");

        try
        {
          bitmap.Save(newFileName, ImageFormat.Gif);
          Console.WriteLine($"Збережено як: {newFileName}");
        }
        catch
        {
          throw new IOException($"Помилка при збереженні файлу \"{newFileName}\".");
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Помилка: {ex.Message}");
      }
    }

    Console.WriteLine("\nОбробка завершена.");
  }
}
