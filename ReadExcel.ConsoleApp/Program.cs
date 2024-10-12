using ReadExcel.ConsoleApp.Services;

namespace ReadExcel.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string directoryPath = @"C:\Users\syedf\Desktop\COMPLETE LOG DIRECTORY\test";  // Update this to your actual directory path

            // Get the list of Excel files using the FileService (Corrected)
            var excelFiles = FileService.GetExcelFiles(directoryPath);


            // Optionally, log the names of each file
            foreach (var file in excelFiles)
            {
                Console.WriteLine($"Found file: {Path.GetFileName(file)}");
            }
            Console.WriteLine($"Number of Excel files found: {excelFiles.Length}");
            Console.WriteLine(" ");

            ReadCsv.ReadCsvFiles(directoryPath);


            var excelSheets = Directory.GetFiles(directoryPath, "*.csv");

            // Process each Excel file
            foreach (var file in excelSheets)
            {
                var logData = InsertIntoLogData.ProcessCsvFile(file);  // Read data from Excel
                if (logData != null)  // Only insert if logData is not null
                {
                    InsertIntoLogData.InsertLogData(logData);  
                    Console.WriteLine($"Data from {file} inserted into db");
                }  // Insert data into the database
                
            }




            // Wait for the user to press a key before closing the console
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();










        }
    }
}
