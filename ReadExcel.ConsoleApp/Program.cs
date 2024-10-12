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
 






            // Wait for the user to press a key before closing the console
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
