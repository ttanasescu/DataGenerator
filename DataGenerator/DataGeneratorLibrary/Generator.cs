using System.Collections.Generic;
using System.Data;
using DataGeneratorLibrary.DAL;
using DataGeneratorLibrary.Generators;

namespace DataGeneratorLibrary
{
    public class Generator
    {
        public void FillTable(DataTable table, IEnumerable<Column> columns, int rowCount,
            bool append)
        {
            var generators = new Dictionary<string, DataTypeGenerator>();

            foreach (var column in columns)
            {
                var generator = DataTypeGenerator.GetGenerator(column);
                generators.Add(column.Name, generator);
            }

            if (!append)
            {
                table.Rows.Clear();
            }

            for (var i = 0; i < rowCount; i++)
            {
                var row = table.NewRow();

                for (var j = 0; j < table.Columns.Count; j++)
                {
                    var columnName = table.Columns[j].ColumnName;
                    row[columnName] = generators[columnName].Generate();
                }

                table.Rows.Add(row);
            }
        }
    }
}
