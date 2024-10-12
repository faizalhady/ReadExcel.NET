using System;
using System.IO;
using System.Collections.Generic;
using ClosedXML.Excel;

namespace ReadExcel.ConsoleApp.Services
{
    public class ReadCsv
    {
        public static void ReadCsvFiles(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                Console.WriteLine($"Directory does not exist: {directoryPath}");
                return;
            }

            var csvFiles = Directory.GetFiles(directoryPath, "*.csv");
            var problematicFiles = new List<string>(); // Store problematic files

            foreach (var file in csvFiles)
            {
                try
                {
                    Console.WriteLine($"\nReading file: {file}");

                    // Convert .csv to .xlsx in-memory for ClosedXML processing
                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Sheet1");

                        // Read the .csv file line by line
                        var csvLines = File.ReadAllLines(file);
                        int rowIndex = 1;

                        foreach (var line in csvLines)
                        {
                            var values = line.Split(',');
                            for (int i = 0; i < values.Length; i++)
                            {
                                worksheet.Cell(rowIndex, i + 1).Value = values[i];
                            }
                            rowIndex++;
                        }

                        // Now that the .csv is loaded, use ClosedXML to read the headers and values
                        var headers = worksheet.Range("A1:H1").Cells();
                        var valuesRange = worksheet.Range("A2:H2").Cells();

                        // Check for issues in the second row (A2:H2)
                        int actualColumnCount = worksheet.Row(2).CellsUsed().Count(); // Get number of actual values in A2 row

                        if (actualColumnCount != 8)
                        {
                            // If there are less or more than 8 values in row 2, mark the file as problematic
                            Console.WriteLine($"[Warning!!!!] This file has an invalid number of values in row 2: {actualColumnCount} (expected 8)");
                            problematicFiles.Add(file);
                        }
                        else
                        {
                            // Log headers
                            Console.WriteLine("Headers:");
                            foreach (var cell in headers)
                            {
                                Console.Write(cell.Value.ToString() + "\t");
                            }
                            Console.WriteLine();

                            // Log values
                            Console.WriteLine("Values:");
                            foreach (var cell in valuesRange)
                            {
                                Console.Write(cell.Value.ToString() + "\t");
                            }
                            Console.WriteLine();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing file {file}: {ex.Message}");
                }
            }

            // Log problematic files at the end
            Console.WriteLine($"\nNumber of problematic files: {problematicFiles.Count}");
            
            if (problematicFiles.Count > 0)
            {
                Console.WriteLine("List of problematic files:");
                 Console.WriteLine("");
                foreach (var problematicFile in problematicFiles)
                {
                    Console.WriteLine(problematicFile);
                }
            }
            else
            {
                Console.WriteLine("No problematic files found.");
            }
        }
    }
}
