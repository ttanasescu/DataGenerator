using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DataGeneratorLibrary.Constrains.DateTime;
using DataGeneratorLibrary.Constrains.Numerics;
using DataGeneratorLibrary.Constrains.Strings;
using DataGeneratorLibrary.Generators;

namespace DataGeneratorLibrary
{
    public class Dal
    {
        //TODO: Singleton

        private readonly string _server;
        private string _database;
        private readonly string _username;
        private readonly string _password;
        private readonly string _connectionString;

        private string ConnectionString => _connectionString == null
            ? $"DataBase={_database};" +
              $"Server={_server};" +
              $"User Id={_username};" +
              $"Password={_password}"
            : (_database != null ? $"DataBase={_database};" + _connectionString : _connectionString);

        public string Database
        {
            set => _database = value;
        }

        public Dal(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Dal(string server, string database, string username, string password)
        {
            _server = server;
            _database = database;
            _username = username;
            _password = password;
        }

        private DataTable ExecuteQuery(string table, string query)
        {
            var dataTable = new DataTable(table);
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    var dataAdapter = new SqlDataAdapter(command);
                    dataAdapter.Fill(dataTable);
                }
            }

            return dataTable;
        }

        public IList<string> GetDataBases()
        {
            var query = @"SELECT name FROM master.dbo.sysdatabases WHERE HAS_DBACCESS(name) = 1 ORDER BY name";
            var table = ExecuteQuery("databases", query);

            var databases = new List<string>();
            var reader = new DataTableReader(table);

            while (reader.Read())
            {
                databases.Add(reader.GetString(0));
            }

            return databases;
        }

        public IList<string> GetTables()
        {
            var query = @"SELECT name FROM sys.tables";
            var table = ExecuteQuery("tables", query);

            var tables = new List<string>();
            var reader = new DataTableReader(table);

            while (reader.Read())
            {
                tables.Add(reader.GetString(0));
            }

            return tables;
        }

        public void ClearTable(string tableName)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var query = @"TRUNCATE TABLE " + tableName;
                using (var command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public DataTable GetTable(string table)
        {
            var query = $@"SELECT * FROM {table}";
            return ExecuteQuery(table, query);
        }

        public void SaveTable(DataTable table)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (var bulkCopy = new SqlBulkCopy(connection))
                {
                    bulkCopy.DestinationTableName = table.TableName;

                    bulkCopy.WriteToServer(table);
                }
            }
        }

        public IList<Column> GetTableInformation(string table)
        {
            var query = $@"SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{table}'";
            var dataTable = ExecuteQuery(table, query);

            IList<Column> columnPropertieses = new List<Column>(dataTable.Rows.Count);

            foreach (DataRow row in dataTable.Rows)
            {
                var column = new Column();

                column.Name = row.Field<string>("COLUMN_NAME");
                column.CharMaxLength = row.Field<int?>("CHARACTER_MAXIMUM_LENGTH");
                column.NumericPrecision = row.Field<byte?>("NUMERIC_PRECISION");
                column.NumericPrecisionRadix = row.Field<short?>("NUMERIC_PRECISION_RADIX");
                column.NumericScale = row.Field<int?>("NUMERIC_SCALE");

                Enum.TryParse(row.Field<string>("DATA_TYPE"), out TSQLDataType dataType);
                column.DataType = dataType;

                switch (column.DataType)
                {
                    case TSQLDataType.@int:
                        column.Constraints = new IntConstraints();
                        break;
                    case TSQLDataType.bigint:
                        column.Constraints = new BigIntConstraints();
                        break;
                    case TSQLDataType.tinyint:
                        column.Constraints = new TinyIntConstraints();
                        break;
                    case TSQLDataType.money:
                        column.Constraints = new MoneyConstraints();
                        break;
                    case TSQLDataType.smallmoney:
                        column.Constraints = new SmallMoneyConstraints();
                        break;
                    case TSQLDataType.numeric:
                    case TSQLDataType.@decimal:
                        column.Constraints = column.NumericPrecision != null && column.NumericScale != null
                            ? new DecimalConstraints(column.NumericPrecision.Value, column.NumericScale.Value)
                            : new DecimalConstraints();
                        //column.constrains = new DecimalConstrains(column.NumericPrecision, column.NumericScale);
                        break;
                    case TSQLDataType.bit:
                        break;
                    case TSQLDataType.smallint:
                        column.Constraints = new SmallIntConstraints();
                        break;
                    case TSQLDataType.@float:
                        column.Constraints = new FloatConstraints();
                        break;
                    case TSQLDataType.real:
                        column.Constraints = new RealConstraints();
                        break;
                    case TSQLDataType.time:
                        column.Constraints = new TimeConstraints();
                        break;
                    case TSQLDataType.date:
                        column.Constraints = new DateConstraints();
                        break;
                    case TSQLDataType.datetime:
                    case TSQLDataType.datetime2:
                        column.Constraints = new Datetime2Constraints();
                        break;
                    case TSQLDataType.smalldatetime:
                        column.Constraints = new SmallDatetimeConstraints();
                        break;
                    case TSQLDataType.datetimeoffset:
                        column.Constraints = new DatetimeOffsetConstraints();
                        break;
                    case TSQLDataType.@char:
                    case TSQLDataType.nchar:
                    case TSQLDataType.binary:
                        column.Constraints = new CharConstraints(column.CharMaxLength);
                        break;
                    case TSQLDataType.text:
                    case TSQLDataType.ntext:
                    case TSQLDataType.nvarchar:
                    case TSQLDataType.varchar:
                        column.Constraints = new VarcharConstraints(column.CharMaxLength);
                        break;
                    case TSQLDataType.image:
                    case TSQLDataType.varbinary:
                        column.Constraints = new VarbinaryConstraints(column.CharMaxLength);
                        break;
                    case TSQLDataType.uniqueidentifier:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                column.Constraints.AllowsNulls = row.Field<string>("IS_NULLABLE") == "YES";

                columnPropertieses.Add(column);
            }

            return columnPropertieses;
        }
    }

    public class Column
    {
        public Constrains.Constraints Constraints { get; set; }
        public string Name { get; set; }
        public TSQLDataType DataType { get; set; }
        public int? CharMaxLength { get; set; }
        public byte? NumericPrecision { get; set; }
        public short? NumericPrecisionRadix { get; set; }
        public int? NumericScale { get; set; }
    }
}