using System.Data;
using System.IO;
using System.Text;
using DataGeneratorLibrary.DAL;
using DataGeneratorLibrary.Generators;

namespace DataGeneratorLibrary.DataExport
{
    public static class SqlScriptGeneraor
    {
        public static void Generate(TableInformation tableInformation, bool addCreateTable, string filePath)
        {
            var builder = new StringBuilder();
            
            builder.Append("INSERT ");
            builder.Append($"[{tableInformation.Columns[0].Schema}].[{tableInformation.Tablename}] "); //TODO Schema

            builder.Append("(");
            foreach (var column in tableInformation.Columns)
            {
                builder.Append($"[{column.Name}], ");
            }

            if (builder[builder.Length - 1] == ' ')
            {
                builder.Length--;
            }

            if (builder[builder.Length - 1] == ',')
            {
                builder.Length--;
            }

            builder.Append(")");

            var columns = builder.ToString();
            builder.Clear();
            

            builder.Append($"USE [{tableInformation.Database}]");
            builder.Append("\r\n");
            builder.Append("GO");
            builder.Append("\r\n");


            if (addCreateTable)
            {
                builder.Append(GetCreateTable(tableInformation, builder));
            }

            foreach (DataRow row in tableInformation.Table.Rows)
            {
                builder.Append(columns);
                builder.Append(" VALUES (");

                for (var i = 0; i < row.ItemArray.Length; i++)
                {
                    builder.Append($"{Formatter.GetString(row[i], tableInformation.Columns[i], i + 1)}, ");
                }

                if (builder[builder.Length - 1] == ' ')
                {
                    builder.Length--;
                }

                if (builder[builder.Length - 1] == ',')
                {
                    builder.Length--;
                }

                builder.Append(")");
                builder.Append("\r\n");
            }

            File.WriteAllText(filePath, builder.ToString());
        }

        private static string GetCreateTable(TableInformation tableInformation, StringBuilder builder)
        {
            builder.Clear();
            builder.Append("SET ANSI_NULLS ON");
            builder.Append("\r\n");
            builder.Append("GO");
            builder.Append("\r\n");
            builder.Append("SET QUOTED_IDENTIFIER ON");
            builder.Append("\r\n");
            builder.Append("GO");
            builder.Append("\r\n");
            builder.Append("SET ANSI_PADDING ON");
            builder.Append("\r\n");
            builder.Append("GO");
            builder.Append("\r\n");

            builder.Append($"CREATE TABLE [{tableInformation.Columns[0].Schema}].[{tableInformation.Tablename}](");

            foreach (var column in tableInformation.Columns)
            {
                builder.Append("\r\n");
                builder.Append($"\t[{column.Name}] [{column.DataType}]");

                switch (column.DataType)
                {
                    case TSQLDataType.@decimal:
                    case TSQLDataType.numeric:
                        if (column.NumericPrecision != null)
                            if (column.NumericScale != null)
                                builder.Append($"({column.NumericPrecision}, {column.NumericScale})");
                        break;
                    case TSQLDataType.time:
                    case TSQLDataType.datetime:
                    case TSQLDataType.datetime2:
                    case TSQLDataType.datetimeoffset:
                    case TSQLDataType.@char:
                    case TSQLDataType.nchar:
                    case TSQLDataType.binary:
                    case TSQLDataType.varchar:
                    case TSQLDataType.nvarchar:
                    case TSQLDataType.varbinary:
                        if (column.CharMaxLength != null) builder.Append($"({column.CharMaxLength})");
                        break;
                }
                builder.Append($"{(column.Constraints.AllowsNulls ? " NULL," : ",")}");
            }

            builder.Length--;

            builder.Append("\r\n");
            builder.Append(")");
            builder.Append("\r\n");
            builder.Append("GO");
            builder.Append("\r\n");

            builder.Append("SET ANSI_PADDING OFF");
            builder.Append("\r\n");
            builder.Append("GO");
            builder.Append("\r\n");
            builder.Append("\r\n");

            var createTable = builder.ToString();
            builder.Clear();
            return createTable;
        }
    }
}