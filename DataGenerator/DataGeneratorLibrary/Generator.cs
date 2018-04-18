using System.Collections.Generic;
using System.Data;
using DataGeneratorLibrary.Generators;

namespace DataGeneratorLibrary
{
    public class Generator
    {
        public void FillTable(DataTable table, IEnumerable<Column> columns, int rowCount,
            bool append)
        {
            var rowdata = new Dictionary<string, IList<object>>(table.Columns.Count);

            foreach (var column in columns)
            {
                var generator = DataTypeGenerator.GetGenerator(column);
                var data = generator.Generate(rowCount);
                rowdata.Add(column.Name, data);
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
                    row[columnName] = rowdata[columnName][i];
                }

                table.Rows.Add(row);
            }
        }
    }
}
