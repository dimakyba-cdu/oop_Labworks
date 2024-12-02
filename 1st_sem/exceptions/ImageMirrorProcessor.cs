using System.Drawing; // Для Bitmap та Image
using System.Drawing.Imaging; // Для ImageFormat

namespace Exceptions
{
  public class ImageMirrorProcessor
  {
    public void ProcessImages(string folderPath)
    {
      if (!Directory.Exists(folderPath))
      {
        Console.WriteLine($"Папка {folderPath} не існує.");
        return;
      }

      var files = Directory.GetFiles(folderPath);

      foreach (var file in files)
      {
        try
        {
          if (!IsImageFile(file))
          {
            Console.WriteLine($"Файл {file} не є зображенням.");
            continue;
          }

          MirrorImage(file);
        }
        catch (Exception ex)
        {
          Console.WriteLine($"Помилка з файлом {file}: {ex.Message}");
        }
      }
    }

    private bool IsImageFile(string filePath)
    {
      string[] validExtensions = { ".jpg", ".jpeg", ".png", ".bmp", ".gif" };
      return validExtensions.Contains(Path.GetExtension(filePath).ToLower());
    }

    private void MirrorImage(string filePath)
    {
      using (var originalImage = Image.FromFile(filePath))
      {
        using (var mirroredImage = new Bitmap(originalImage))
        {
          mirroredImage.RotateFlip(RotateFlipType.RotateNoneFlipY);

          string newFileName = Path.Combine(
              Path.GetDirectoryName(filePath),
              $"{Path.GetFileNameWithoutExtension(filePath)}_mirrored.gif"
          );
          mirroredImage.Save(newFileName, ImageFormat.Gif);

          Console.WriteLine($"Зображення збережено: {newFileName}");
        }
      }
    }
  }
}
