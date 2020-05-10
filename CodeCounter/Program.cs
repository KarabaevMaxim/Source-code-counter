using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeCounter
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var totalFiles = new List<string>();

      while (true)
      {
        Console.WriteLine("Введи путь или 0, чтобы приступить к расчету");
        var input = Console.ReadLine();
        
        if(input == "0")
          break;

        if (Directory.Exists(input))
        {
          var files = GetFilesInDirectory(input);
          Console.WriteLine($"Найдено {files.Count()} файлов");
          totalFiles.AddRange(files);
        }
        else
        {
          Console.WriteLine("Папка не найдена");
        }
      }

      if(totalFiles.Count == 0)
        return;
      
      var totalLines = 0;
      
      foreach (var file in totalFiles)
      {
        var lines = File.ReadAllLines(file);
        Console.WriteLine($"Файл {Path.GetFileName(file)} строк: {lines.Length}");
        totalLines += lines.Length;
      }
      
      Console.WriteLine($">>>>>> Всего строк {totalLines}. Всего файлов исходников {totalFiles.Count}");
    }

    private static IEnumerable<string> GetFilesInDirectory(string dirPath)
    {
      return Directory.GetFiles(dirPath, "*.*", SearchOption.AllDirectories)
        .Where(f => Path.GetExtension(f) == ".cs");
    }
  }
}