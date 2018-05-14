using System;
using DataGeneratorLibrary.DAL;
using DataGeneratorLibrary.Generators;

namespace DataGeneratorLibrary.DataExport
{
    internal static class Formatter
    {
        private static string ByteArrayToHex(byte[] bytes)
        {
            var lookup = new uint[256];
            for (var i = 0; i < 256; i++)
            {
                var s = i.ToString("X2");
                lookup[i] = s[0] + ((uint)s[1] << 16);
            }

            var result = new char[bytes.Length * 2];
            for (var i = 0; i < bytes.Length; i++)
            {
                var val = lookup[bytes[i]];
                result[2 * i] = (char)val;
                result[2 * i + 1] = (char)(val >> 16);
            }
            return new string(result);
        }

        public static string GetString(object o, Column c, int i)
        {
            if (i!= c.OdinalPosition)
            {
                throw new ArgumentException(nameof(i));
            }

            var str = o.ToString();

            switch (c.DataType)
            {
                case TSQLDataType.bigint:
                    break;
                case TSQLDataType.numeric:
                    break;
                case TSQLDataType.bit:
                    break;
                case TSQLDataType.smallint:
                    break;
                case TSQLDataType.@float:
                    break;
                case TSQLDataType.real:
                    break;
                case TSQLDataType.@decimal:
                    break;
                case TSQLDataType.smallmoney:
                    break;
                case TSQLDataType.@int:
                    break;
                case TSQLDataType.tinyint:
                    break;
                case TSQLDataType.money:
                    break;
                case TSQLDataType.time:
                    str = ((TimeSpan)o).ToString(@"hh\:mm\:ss\.fffffff");
                    break;
                case TSQLDataType.date:
                    str = ((DateTime)o).ToString("yyyy-MM-dd");
                    break;
                case TSQLDataType.smalldatetime:
                    str = ((DateTime) o).ToString("yyyy-MM-dd HH:mm:ss");
                    break;
                case TSQLDataType.datetime:
                    str = ((DateTime)o).ToString("yyyy-MM-dd HH:mm:ss.fff");
                    break;
                case TSQLDataType.datetime2:
                    str = ((DateTime)o).ToString("yyyy-MM-dd HH:mm:ss.fffffff");
                    break;
                case TSQLDataType.datetimeoffset:
                    str = ((DateTimeOffset) o).ToString("yyyy-MM-dd HH:mm:ss.fffffff zzz");
                    break;
                case TSQLDataType.ntext:
                case TSQLDataType.text:
                case TSQLDataType.@char:
                case TSQLDataType.varchar:
                case TSQLDataType.nchar:
                case TSQLDataType.nvarchar:
                    str= o.ToString().Replace("'", "''");
                break;
                case TSQLDataType.image:
                case TSQLDataType.binary:
                case TSQLDataType.varbinary:
                    var s = ByteArrayToHex(o as byte[]??new byte[0]);
                    return s.Length>0? $"0x{s}" :"NULL";
                case TSQLDataType.uniqueidentifier:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return string.IsNullOrEmpty(str) ? "NULL" : $"N\'{str}\'";
        }
    }
}
