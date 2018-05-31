using System;
using System.Data;
using System.IO;
using System.Text;
using DataGeneratorLibrary.DAL;

namespace DataGeneratorLibrary.DataExport
{
    public static class CSVGenerator
    {
        public static void Generate(TableInformation tableInformation, string filePath)
        {
            var builder = new StringBuilder();

            foreach (var column in tableInformation.Columns)
            {
                builder.Append(column.Name.ToLower());
                builder.Append(",");
            }

            if (builder[builder.Length - 1] == ',')
            {
                builder.Length--;
            }

            builder.Append(Environment.NewLine);

            foreach (DataRow row in tableInformation.Table.Rows)
            {
                IFormatter formatter = new CsvFormatter();

                for (var i = 0; i < row.ItemArray.Length; i++)
                {
                    var column = tableInformation.Columns[i];
                    if (i + 1 != column.OdinalPosition)
                    {
                        throw new ArgumentException(nameof(i));
                    }

                    builder.Append($"{formatter.GetString(row[i], column)},");
                }

                if (builder[builder.Length - 1] == ',')
                {
                    builder.Length--;
                }

                builder.Append(Environment.NewLine);
            }

            File.WriteAllText(filePath, builder.ToString());
        }
    }
}