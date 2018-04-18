using System;
using System.Collections.Generic;
using System.Data;
using DataGeneratorLibrary.Generators.DateTime;
using DataGeneratorLibrary.Generators.Numerics;
using DataGeneratorLibrary.Generators.Other;
using DataGeneratorLibrary.Helpers;
using static DataGeneratorLibrary.Helpers.Extensions;

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

    public abstract class DataTypeGenerator
    {
        protected Column Column { get; }

        protected DataTypeGenerator(Column column)
        {
            Column = column;
            Random = RandomGenerator.Instance;
        }

        public abstract object Generate();
        protected readonly Random Random;

        public IList<object> Generate(int count)
        {
            var values = new List<object>(count);
            for (var i = 0; i < count; i++)
            {
                values.Add(Generate());
            }

            return values;
        }

        public IList<object> GenerateUnique(int count)
        {
            var values = new List<object>(count);
            for (var i = 0; i < count; i++)
            {
                var value = Generate();
                if (!values.Contains(value))
                {
                    values.Add(Generate());
                }
                else
                {
                    i--;
                    //TODO: rewrite
                }
            }

            return values;
        }

        public static DataTypeGenerator GetGenerator(Column column)
        {
            switch (column.DataType)
            {
                case TSQLDataType.bit:
                    return new BitGenerator(column);
                case TSQLDataType.tinyint:
                    return new TinyIntGenerator(column);
                case TSQLDataType.smallint:
                    return new SmallIntGenerator(column);
                case TSQLDataType.@int:
                    return new IntGenerator(column);
                case TSQLDataType.bigint:
                    return new BigIntGenerator(column);

                case TSQLDataType.@float:
                    return new FloatGenerator(column);
                case TSQLDataType.real:
                    return new RealGenerator(column);

                case TSQLDataType.numeric:
                case TSQLDataType.@decimal:
                case TSQLDataType.money:
                case TSQLDataType.smallmoney:
                    return new DecimalsGenerator(column);

                case TSQLDataType.time:
                    return new TimeGenerator(column);
                case TSQLDataType.date:
                    return new DateGenerator(column);
                case TSQLDataType.datetime:
                    return new Datetime2Generator(column);
                case TSQLDataType.datetime2:
                    return new Datetime2Generator(column);
                case TSQLDataType.smalldatetime:
                    return new SmallDatetimeGenerator(column);
                case TSQLDataType.datetimeoffset:
                    return new DatetimeOffsetGenerator(column);


                case TSQLDataType.text:
                case TSQLDataType.ntext:
                case TSQLDataType.@char:
                case TSQLDataType.varchar:
                case TSQLDataType.nchar:
                case TSQLDataType.nvarchar:
                    return new StringGenerator(column);

                case TSQLDataType.image:
                case TSQLDataType.binary:
                case TSQLDataType.varbinary:
                    return new BinaryGenerator(column);

                case TSQLDataType.uniqueidentifier:
                    return new UniqueIdentifierGenerator(column);



                default:
                    throw new NotImplementedException();
            }
        }
    }


    public class Constrains
    {
    }

    public class StringConstrains : Constrains
    {
        protected int MinLengthValue = 1;
        protected int MaxLengthValue;

        protected int MinPossibleLength = 1;
        protected int MaxPossibleLength = int.MaxValue;

        public int MaxLength
        {
            get => Constrain(MaxLengthValue, MinPossibleLength, MaxPossibleLength);
            set => MaxLengthValue = value;
        }

        public virtual int MinLength
        {
            get => Constrain(MinLengthValue, MinPossibleLength, MaxPossibleLength);
            set => MinLengthValue = value;
        }

        public StringConstrains(int maxLength)
        {
            MaxLength = maxLength;
        }
    }

    public class CharConstrains : StringConstrains
    {
        public override int MinLength
        {
            get => Constrain(MaxLengthValue, MinPossibleLength, MaxPossibleLength);
            set => MaxLengthValue = value;
        }

        public CharConstrains(int maxLength) : base(maxLength)
        {
            MaxPossibleLength = 8000;
        }
    }
    public class BinaryConstrains : CharConstrains
    {
        public BinaryConstrains(int maxLength) : base(maxLength)
        {
        }
    }

    public class VarcharConstrains : StringConstrains
    {
        public VarcharConstrains(int maxLength) : base(maxLength)
        {
            MaxPossibleLength = 8000;
        }
    }


    public class VarbinaryConstrains : VarcharConstrains
    {
        public VarbinaryConstrains(int maxLength) : base(maxLength)
        {
        }
    }

    public class ImageConstrains : VarcharConstrains
    {
        public ImageConstrains(int maxLength = 50) : base(maxLength)
        {
            MaxPossibleLength = 2147483647;
        }
    }

    public class TextConstrains : VarcharConstrains
    {
        public TextConstrains(int maxLength = 50) : base(maxLength)
        {
            MaxPossibleLength = 2147483647;
        }
    }

    public class NtextConstrains : VarcharConstrains
    {
        public NtextConstrains(int maxLength = 50) : base(maxLength)
        {
            MaxPossibleLength = 1073741823;
        }
    }

    public class TinyIntConstrains : Constrains
    {
        public byte MinValue { get; set; } = byte.MinValue;
        public byte MaxValue { get; set; } = byte.MaxValue;
    }

    public class SmallIntConstrains : Constrains
    {
        public short MinValue { get; set; } = short.MinValue;
        public short MaxValue { get; set; } = short.MaxValue;
    }

    public class IntConstrains : Constrains
    {
        public int MinValue { get; set; } = int.MinValue;
        public int MaxValue { get; set; } = int.MaxValue;
    }

    public class FloatConstrains : Constrains
    {
        public double MinValue { get; set; } = double.MinValue;
        public double MaxValue { get; set; } = double.MaxValue;
    }

    public class RealConstrains : Constrains
    {
        public float MinValue { get; set; } = float.MinValue;
        public float MaxValue { get; set; } = float.MaxValue;
    }

    public class BigIntConstrains : Constrains
    {
        public long MinValue { get; set; } = long.MinValue;
        public long MaxValue { get; set; } = long.MaxValue;
    }

    public class UniqueIdentifierConstrains : Constrains
    {
    }

    public class DecimalConstrains : Constrains
    {
        private decimal _minValue = decimal.MinValue;
        private decimal _maxValue = decimal.MaxValue;

        public virtual decimal MinValue
        {
            get => _minValue;
            set => _minValue = value;
        }

        public virtual decimal MaxValue
        {
            get => _maxValue;
            set => _maxValue = value;
        }

        public DecimalConstrains(byte precision, int scale)
        {
            if (precision > 38 || precision < 0)
            {
                throw new ArgumentOutOfRangeException(precision.ToString());
            }

            if (scale < 0 || scale > precision)
            {
                throw new ArgumentOutOfRangeException(scale.ToString());
            }

            var maxValueString = $"{new string('9', precision - scale)}.{new string('9', scale)}";

            decimal.TryParse(maxValueString, out var maxValue);
            _minValue = decimal.Negate(maxValue);
            _maxValue = maxValue;
        }

        public DecimalConstrains()
        {
        }
    }

    public class SmallMoneyConstrains : DecimalConstrains
    {
        private decimal _minValue = -214748.3648m;
        private decimal _maxValue = 214748.3647m;
        
        public override decimal MinValue
        {
            get => _minValue;
            set
            {
                if (value >= -214748.3648m)
                {
                    _minValue = value <= MaxValue ? value : MaxValue;
                }
                else
                    _minValue = -214748.3648m;
            }
        }

        public override decimal MaxValue
        {
            get => _maxValue;
            set
            {
                if (value <= 214748.3647m)
                {
                    _maxValue = value >= MinValue ? value : MinValue;
                }
                _maxValue = 214748.3647m;
            }
        }
    }

    public class MoneyConstrains : DecimalConstrains
    {
        private decimal _minValue = -922337203685477.5808m;
        private decimal _maxValue = 922337203685477.5807m;

        public override decimal MinValue
        {
            get => _minValue;
            set
            {
                if (value >= -922337203685477.5808m)
                {
                    _minValue = value <= MaxValue ? value : MaxValue;
                }
                else
                    _minValue = -922337203685477.5808m;
            }
        }

        public override decimal MaxValue
        {
            get => _maxValue;
            set
            {
                if (value <= 922337203685477.5807m)
                {
                    _maxValue = value >= MinValue ? value : MinValue;
                }

                _maxValue = 922337203685477.5807m;
            }
        }
    }

    public class Datetime2Constrains : Constrains
    {
        public DateTime MinDatetime { get; set; } = DateTime.MinValue;
        public DateTime MaxDatetime { get; set; } = DateTime.MaxValue;
    }

    public class DatetimeConstrains : Datetime2Constrains
    {
        public DatetimeConstrains()
        {
            MinDatetime = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            MaxDatetime = new DateTime(9999, 12, 31, 23, 59, 59, 997);
        }
    }

    public class SmallDatetimeConstrains : Datetime2Constrains
    {
        public SmallDatetimeConstrains()
        {
            MinDatetime = new DateTime(1900, 1, 1, 0, 0, 0);
            MaxDatetime = new DateTime(2079, 6, 6, 23, 59, 59);
        }
    }

    public class DatetimeOffsetConstrains : Constrains
    {
        public DateTimeOffset MinDatetime { get; set; }
        public DateTimeOffset MaxDatetime { get; set; }

        public TimeSpan MinOffset { get; set; }
        public TimeSpan MaxOffset { get; set; }

        public DatetimeOffsetConstrains()
        {
            MinOffset = new TimeSpan(-14, 0, 0);
            MaxOffset = new TimeSpan(14, 0, 0);

            MinDatetime = new DateTimeOffset(DateTime.MinValue, MinOffset);
            MaxDatetime = new DateTimeOffset(DateTime.MaxValue, MaxOffset);
        }
    }

    public class DateConstrains : Constrains
    {
        public DateTime MinDate { get; set; } = new DateTime(0001, 1, 1);
        public DateTime MaxDate { get; set; } = new DateTime(9999, 12, 31);
    }

    public class TimeConstrains : Constrains
    {
        public TimeSpan MinTime { get; set; } = new TimeSpan(0,0,0,0,0);
        public TimeSpan MaxTime { get; set; } = new TimeSpan(0, 23, 59, 59, 9999999);
    }

}
