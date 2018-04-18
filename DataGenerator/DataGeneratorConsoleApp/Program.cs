using System;
using System.Configuration;
using System.Data;
using System.Linq;
using DataGeneratorLibrary;
using DataGeneratorLibrary.Constrains.Numerics;
using DataGeneratorLibrary.Generators;

namespace DataGeneratorConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var tablename = "Table_4";
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            var dal = new Dal(connectionString);
            
            var dataBases = dal.GetDataBases();
            Console.WriteLine("Databases:");
            foreach (var row in dataBases)
            {
                Console.WriteLine($"  -{row}");
            }
            
            var tables = dal.GetTables();
            Console.WriteLine();
            Console.WriteLine("3ds Tables:");
            foreach (var row in tables)
            {
                Console.WriteLine($"  -{row}");
            }

            var columns = dal.GetTableInformation(tablename);
            //            Console.WriteLine();
            //            Console.WriteLine("Titles Table:");
            //
            //            foreach (DataColumn column in tableInformation.Columns)
            //            {
            //                Console.Write($"{column.ColumnName}({column.DataType})|");
            //            }
            //
            //            for (var i = 0; i < 10; i++)
            //            {
            //                foreach (var cell in tableInformation.Rows[0].ItemArray)
            //                {
            //                    Console.Write($"{cell}|");
            //                }
            //
            //                Console.WriteLine();
            //            }

            
            var table = dal.GetTable(tablename);
            Console.WriteLine();
            Console.WriteLine($"{tablename} Table:");

            var generator = new Generator();

            var enumerable = columns.ToList();
            foreach (var column in enumerable)
            {
                switch (column.DataType)
                {
                    case TSQLDataType.@int:
                        column.constrains = new IntConstrains();// { MinValue = 5, MaxValue = 300 };
                        break;
                    case TSQLDataType.bigint:
                        column.constrains = new BigIntConstrains { MinValue = 5, MaxValue = 300 }; //();
                        break;
                    case TSQLDataType.money:
                        column.constrains = new MoneyConstrains();
                        break;
                    case TSQLDataType.smallmoney:
                        column.constrains = new SmallMoneyConstrains();
                        break;
                    case TSQLDataType.numeric:
                    case TSQLDataType.@decimal:
                        column.constrains = column.NumericPrecision != null && column.NumericScale != null
                        ? new DecimalConstrains(column.NumericPrecision.Value, column.NumericScale.Value)
                        : new DecimalConstrains();
                        //column.constrains = new DecimalConstrains(column.NumericPrecision, column.NumericScale);
                        break;
                }
            }
            generator.FillTable(table, enumerable, 10, false);

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


            Console.ReadKey();
        }
    }
}
