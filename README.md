# CsvExtracter

A .NET console application to extract specified columns from a CSV file.

## Requirements
- .NET 6.0 SDK

## Build
    dotnet build

## Run
    dotnet run --project src/CsvExtracter -- <inputCsvPath> <outputCsvPath> <column1> [<column2> ...]

Example:
    dotnet run --project src/CsvExtracter -- input.csv output.csv Name Age
