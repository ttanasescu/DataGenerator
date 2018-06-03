using System;
using System.Configuration;
using System.Data;
using DataGeneratorLibrary;
using DataGeneratorLibrary.Constrains.Numerics;
using DataGeneratorLibrary.DAL;
using DataGeneratorLibrary.Generators;
using RegExGenerator;

namespace DataGeneratorConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new RegExParser(@"[--5-6-\]]{2,5}|[\w-C-y]?\"); //RegExParser("(a*)|(x|z){2,5}");

            var regEx = parser.Parse();

            regEx.Print("", true);

            Console.ReadKey();
            /*
#if DEBUG
            var connectionString = ConfigurationManager.ConnectionStrings["TestDBConnection"].ConnectionString;
            var dal = Dal.Instance;//new Dal(connectionString);
            var tablename = "Table_4";
#else
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            var dal = Dal.Instance;//new Dal(connectionString);
            GetDatabaseName(dal);
            var tablename = GetTableName(dal);
#endif

            var columns = dal.GetTableInformation(tablename);

            var table = dal.GetTable(tablename);
            Console.WriteLine();
            Console.WriteLine($"{tablename} Table:");

            var generator = new Generator();
            
            foreach (var column in columns)
            {
                switch (column.DataType)
                {
                    case TSQLDataType.@int:
                        column.Constraints = new IntConstraints(); // { MinValue = 5, MaxValue = 300 };
                        break;
                    case TSQLDataType.bigint:
                        column.Constraints = new BigIntConstraints {MinValue = 5, MaxValue = 300}; //();
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
                }
            }

            generator.FillTable(table, columns, 10, false);

            dal.ClearTable(tablename);


            foreach (DataColumn column in table.Columns)
            {
                Console.Write($"{column.ColumnName}({column.DataType})|");
            }

            Console.WriteLine();

            foreach (DataRow row in table.Rows)
            {
                foreach (var cell in row.ItemArray)
                {
                    Console.Write($"{cell} ".PadRight(19));
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            dal.SaveTable(table);

            Console.ReadKey();*/
        }


#if !DEBUG
        
        private static string GetTableName(Dal dal)
        {
            var tables = dal.GetTables();
            var tablename = "";

            while (!tables.Contains(tablename))
            {
                Console.Clear();
                Console.WriteLine("Tables:");
                foreach (var name in tables)
                {
                    Console.WriteLine($"  -{name}");
                }

                Console.WriteLine("\nEnter table name:");
                tablename = Console.ReadLine();
            }

            return tablename;
        }

        private static void GetDatabaseName(Dal dal)
        {
            var dataBases = dal.GetDataBases();
            var database = "";

            while (!dataBases.Contains(database))
            {
                Console.Clear();
                Console.WriteLine("Databases:");
                foreach (var name in dataBases)
                {
                    Console.WriteLine($"  -{name}");
                }

                Console.WriteLine("\nEnter database name:");

                database = Console.ReadLine();
            }

            dal.SqlConnectionStringBuilder.InitialCatalog = database;
        }
#endif
    }
}
