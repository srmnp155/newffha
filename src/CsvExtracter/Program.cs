using System;
using System.Linq;
using CsvExtracter.Services;

namespace CsvExtracter
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 3)
            {
                Console.WriteLine("Usage: CsvExtracter <inputCsvPath> <outputCsvPath> <column1> [<column2> ...]");
                return;
            }

            var inputPath = args[0];
            var outputPath = args[1];
            var columns = args.Skip(2).ToArray();

            try
            {
                CsvExtractionService.Extract(inputPath, outputPath, columns);
                Console.WriteLine($"Extraction completed. Output saved to {outputPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
