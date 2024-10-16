﻿using ReadExcel.ConsoleApp.Services;

namespace ReadExcel.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Program run at: {DateTime.Now}\n");
            string directoryPath = @"C:\Users\syedf\Desktop\COMPLETE LOG DIRECTORY\test";  

            // simpan list files dalam string[]
            var excelFiles = FileService.GetExcelFiles(directoryPath);


            // log nama file
            // foreach (var file in excelFiles)
            // {
            //     Console.WriteLine($"Found file: {Path.GetFileName(file)}");
            // }
            Console.WriteLine($"Number of .csv files found: {excelFiles.Length}");
            
            // Console.WriteLine(" ");

            // ReadCsv.ReadCsvFiles(directoryPath);


            var excelSheets = Directory.GetFiles(directoryPath, "*.csv");

            
            foreach (var file in excelSheets)
            {
                var logData = InsertIntoLogData.ProcessCsvFile(file);  
                if (logData != null)  
                {
                    InsertIntoLogData.InsertLogData(logData);  
                    // Console.WriteLine($"Data from {file} inserted into db");
                }  
                
            }

            Console.WriteLine($"Number of rejected .csv files: {InsertIntoLogData.RejectedFileCount}");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();










        }
    }
}
