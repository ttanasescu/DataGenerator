﻿using System;
using System.Globalization;
using DataGeneratorLibrary.DAL;
using DataGeneratorLibrary.Generators;
using DataGeneratorLibrary.Helpers;

namespace DataGeneratorLibrary.DataExport
{
    internal class SqlFormatter : IFormatter
    {
        public string GetString(object @object, Column column)
        {
            var str = @object.ToString();

            bool addQuotes = false;

            switch (column.DataType)
            {
                case TSQLDataType.bigint:
                    break;
                case TSQLDataType.numeric:
                    break;
                case TSQLDataType.bit:
                    addQuotes = true;
                    break;
                case TSQLDataType.smallint:
                    break;
                case TSQLDataType.@int:
                    break;
                case TSQLDataType.tinyint:
                    break;
                case TSQLDataType.@float:
                    break;
                case TSQLDataType.real:
                    str = ((float) @object).ToString(CultureInfo.GetCultureInfo("en-US"));
                    break;
                case TSQLDataType.@decimal:
                    str = ((decimal) @object).ToString(CultureInfo.GetCultureInfo("en-US"));
                    break;
                case TSQLDataType.money:
                    str = ((decimal) @object).ToString(CultureInfo.GetCultureInfo("en-US"));
                    break;
                case TSQLDataType.smallmoney:
                    str = ((decimal) @object).ToString(CultureInfo.GetCultureInfo("en-US"));
                    break;
                case TSQLDataType.time:
                    str = ((TimeSpan) @object).ToString(@"hh\:mm\:ss\.fffffff");
                    addQuotes = true;
                    break;
                case TSQLDataType.date:
                    str = ((DateTime) @object).ToString("yyyy-MM-dd");
                    addQuotes = true;
                    break;
                case TSQLDataType.smalldatetime:
                    str = ((DateTime) @object).ToString("yyyy-MM-dd HH:mm:ss");
                    addQuotes = true;
                    break;
                case TSQLDataType.datetime:
                    str = ((DateTime) @object).ToString("yyyy-MM-dd HH:mm:ss.fff");
                    addQuotes = true;
                    break;
                case TSQLDataType.datetime2:
                    str = ((DateTime) @object).ToString("yyyy-MM-dd HH:mm:ss.fffffff");
                    addQuotes = true;
                    break;
                case TSQLDataType.datetimeoffset:
                    str = ((DateTimeOffset) @object).ToString("yyyy-MM-dd HH:mm:ss.fffffff zzz");
                    addQuotes = true;
                    break;
                case TSQLDataType.ntext:
                case TSQLDataType.text:
                case TSQLDataType.@char:
                case TSQLDataType.varchar:
                case TSQLDataType.nchar:
                case TSQLDataType.nvarchar:
                    str = @object.ToString().Replace("'", "''");
                    addQuotes = true;
                    break;
                case TSQLDataType.image:
                case TSQLDataType.binary:
                case TSQLDataType.varbinary:
                    var s = (@object as byte[] ?? new byte[0]).ByteArrayToHex();
                    return s.Length > 0 ? $"0x{s}" : "NULL";
                case TSQLDataType.uniqueidentifier:
                    addQuotes = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (string.IsNullOrEmpty(str))
            {
                return "NULL";
            }

            return addQuotes ? $"N'{str}'" : str;
        }
    }
}
