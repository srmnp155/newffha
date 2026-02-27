using System;
using System.IO;
using System.Linq;
using System.Globalization;
using CsvHelper;

namespace CsvExtracter.Services
{
    public static class CsvExtractionService
    {
        public static void Extract(string inputPath, string outputPath, string[] columns)
        {
            using var reader = new StreamReader(inputPath);
            using var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);
            csvReader.Read();
            csvReader.ReadHeader();
            var headerRow = csvReader.HeaderRecord;
            var selectedIndexes = headerRow
                .Select((h, index) => new { h, index })
                .Where(x => columns.Contains(x.h, StringComparer.OrdinalIgnoreCase))
                .Select(x => x.index)
                .ToArray();

            using var writer = new StreamWriter(outputPath);
            using var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);

            foreach (var index in selectedIndexes)
            {
                csvWriter.WriteField(headerRow[index]);
            }
            csvWriter.NextRecord();

            while (csvReader.Read())
            {
                foreach (var index in selectedIndexes)
                {
                    csvWriter.WriteField(csvReader.GetField(index));
                }
                csvWriter.NextRecord();
            }
        }
    }
}
