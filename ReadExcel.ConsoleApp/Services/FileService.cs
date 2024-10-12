using System;

namespace ReadExcel.ConsoleApp.Services;

public class ReadExcel
{
public static string[] GetExcelFiles(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                Console.WriteLine($"Directory does not exist: {directoryPath}");
                return Array.Empty<string>();
            }
            
            var excelFiles = Directory.GetFiles(directoryPath, "*.xlsx");
            return excelFiles;
        }
}
