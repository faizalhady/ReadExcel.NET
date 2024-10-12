using System;
using System.IO;


namespace ReadExcel.ConsoleApp.Services  // Update with your actual namespace
{
    public class InsertIntoLogData
    {
        // Method to process CSV file and extract data from A2:H2 (which is line 2)
        public static LogData ProcessCsvFile(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            
            if (lines.Length < 2)
            {
                throw new Exception($"File {filePath} doesn't have enough rows to process.");
            }

            // Read the second row (A2:H2 corresponds to line 2)
            var values = lines[1].Split(',');

            if (values.Length != 8)
            {
                InsertRejectedFile(filePath);  // Insert the file name into the RejectedFile table
                
                return null;  // Skip processing this file
            }

            // Create and return a new LogData object with the values
            return new LogData
            {
                Model = values[0],
                SerialNo = values[1],
                Process = values[2],
                Timestamp = DateTime.Parse(values[3]),  // Parse timestamp from the CSV
                SoftwareVersion = values[4],
                Status = values[5],
                PCName = values[6],
                IPAddress = values[7]
            };
        }

        public static void InsertRejectedFile(string filePath)
        {
            using (var context = new LogDbContext())
            {
                var rejectedFile = new RejectedFile
                {
                    FileName = Path.GetFileName(filePath)  // Extract only the file name
                };

                context.RejectedFiles.Add(rejectedFile);
                Console.WriteLine($"Data from {filePath} is rejected");
                context.SaveChanges();
                
            }
        }
        public static void InsertLogData(LogData logData)
        {
            using (var context = new LogDbContext())
            {
                context.LogData.Add(logData);
                context.SaveChanges();
                
            }
        }
    }
}
