using System;
using System.IO;

namespace ReadExcel.ConsoleApp.Services;

public class FileService
{
public static string[] GetExcelFiles(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                Console.WriteLine($"Directory does not exist: {directoryPath}");
                return Array.Empty<string>();
            }
            
            var excelFiles = Directory.GetFiles(directoryPath, "*.csv");
            return excelFiles;
        }
}
