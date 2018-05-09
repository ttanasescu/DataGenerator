using System.Collections.Generic;
using System.Data;

namespace DataGeneratorLibrary.DAL
{
    public class TableInformation
    {
        public DataTable Table { get; set; }
        public IList<Column> Columns { get; set; }
        public string Tablename { get; set; }
        public string Database { get; set; }
        public string ServerName { get; set; }
    }
}
