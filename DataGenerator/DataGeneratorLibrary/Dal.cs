using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DataGeneratorLibrary.Generators;

namespace DataGeneratorLibrary
{
    public class Dal
    {
        //TODO: Singleton

        private static string _server;
        private static string _database;
        private static string _username;
        private static string _password;

        private string ConnectionString =>
            $"Server={_server};DataBase={_database};User Id={_username};Password={_password}";

        public void ConnectToDatabase(string server, string database, string username, string password)
        {
            _server = server;
            _database = database;
            _username = username;
            _password = password;
            //Connection = new SqlConnection(ConnectionString);
        }

        public IEnumerable<string> GetDataBases()
        {
            var columnData = new List<string>();
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var query = @"SELECT name FROM master.dbo.sysdatabases WHERE HAS_DBACCESS(name) = 1 ORDER BY name";
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            columnData.Add(reader.GetString(0));
                        }
                    }
                }
            }

            return columnData;
        }



        public IEnumerable<string> GetTables()
        {
            var columnData = new List<string>();
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var query = @"SELECT name FROM sys.tables";
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            columnData.Add(reader.GetString(0));
                        }
                    }
                }
            }

            return columnData;
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
            var dataTable = new DataTable(table);
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var query = $@"SELECT * FROM {table}";
                using (var command = new SqlCommand(query, connection))
                {
                    var dataAdapter = new SqlDataAdapter(command);
                    dataAdapter.Fill(dataTable);
                }
            }

            return dataTable;
        }

        public void SaveTable(DataTable table)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (var bulkCopy = new SqlBulkCopy(connection))
                {
                    bulkCopy.DestinationTableName = table.TableName;

//                    try
//                    {
//                        // Write from the source to the destination.
                        bulkCopy.WriteToServer(table);
//                    }
//                    catch (Exception ex)
//                    {
//                        Console.WriteLine(ex.Message);
//                    }
                }
            }
        }

        public IEnumerable<Column> GetTableInformation(string table)
        {
            var dataTable = new DataTable();
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var query = $@"SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{table}'";
                using (var command = new SqlCommand(query, connection))
                {
                    var dataAdapter = new SqlDataAdapter(command);
                    dataAdapter.Fill(dataTable);
                }
            }

            IList<Column> columnPropertieses = new List<Column>(dataTable.Rows.Count);

            foreach (DataRow row in dataTable.Rows)
            {
                var properties = new Column();

                properties.Name = row.Field<string>("COLUMN_NAME");
                properties.CharMaxLength = row.Field<int?>("CHARACTER_MAXIMUM_LENGTH");
                properties.NumericPrecision = row.Field<byte?>("NUMERIC_PRECISION");
                properties.NumericPrecisionRadix = row.Field<short?>("NUMERIC_PRECISION_RADIX");
                properties.NumericScale = row.Field<int?>("NUMERIC_SCALE");


                Enum.TryParse(row.Field<string>("DATA_TYPE"), out TSQLDataType dataType);
                properties.DataType = dataType;

                columnPropertieses.Add(properties);
            }

            return columnPropertieses;
        }
    }

    public class Column
    {
        public Constrains.Constrains constrains { get; set; }
        public string Name { get; set; }
        public TSQLDataType DataType { get; set; }
        public int? CharMaxLength { get; set; }
        public byte? NumericPrecision { get; set; }
        public short? NumericPrecisionRadix { get; set; }
        public int? NumericScale { get; set; }
    }
}