using System;

namespace DataGeneratorLibrary
{
    public class ExactNumericsGenerator : DataTypeGenerator
    {
        public ExactNumericsGenerator(Column column) : base(column)
        {
        }

        public override object Generate()
        {
            switch (Column.DataType)
            {
//                case TSQLDataType.@int:
                //return GenerateInt(Column);
//                case TSQLDataType.bit:
//                    return GenerateBit(Column);
//                case TSQLDataType.tinyint:
//                    return GenerateTinyInt(Column);
//                case TSQLDataType.smallint:
//                    return GenerateSmallInt(Column);
//                case TSQLDataType.bigint:
//                    return GenerateBigInt(Column);
                case TSQLDataType.numeric:
                case TSQLDataType.@decimal:
                    throw new NotImplementedException();

                //                    Constrains = Column.NumericPrecision != null && Column.NumericScale != null
                //                        ? new DecimalConstrains(Column.NumericPrecision.Value, Column.NumericScale.Value)
                //                        : new DecimalConstrains();
                //return GenerateDecimal(Column);

//                case TSQLDataType.money:
//                    throw new NotImplementedException();
//                    //return GenerateDecimal(Column);
//                case TSQLDataType.smallmoney:
//                    return GenerateDecimal(Column);
                default:
                    throw new NotImplementedException();
            }
        }

//        private decimal GenerateDecimal(Column column)
//        {
//            var precision = column.NumericPrecision ?? 28;
//            var scale1 = column.NumericScale ?? 0;
//
//            var maxValueString = $"{new string('9', precision - scale1)}.{new string('9', scale1)}";
//
//            decimal.TryParse(maxValueString, out var maxValue);
//            var minValue = decimal.Negate(maxValue);
//
//            if (Constrains is DecimalConstrains decimalConstrains)
//            {
//                minValue = decimalConstrains.MinValue;
//                maxValue = decimalConstrains.MaxValue;
//            }
//
//            var minValueScale = new SqlDecimal(minValue).Scale;
//            var maxValueScale = new SqlDecimal(maxValue).Scale;
//
//            var scale = (byte)(minValueScale + maxValueScale);
//            if (scale > 28)
//                scale = 28;
//            
//            var range = new decimal(Random.Next(), Random.Next(), Random.Next(), false, scale);
//            if (Math.Sign(minValue) == Math.Sign(maxValue) || minValue == 0 || maxValue == 0)
//                return decimal.Remainder(range, maxValue - minValue) + minValue;
//
//            var isNegativeRange = (double)minValue + Random.NextDouble() * ((double)maxValue - (double)minValue) < 0;
//            return isNegativeRange ? decimal.Remainder(range, -minValue) + minValue : decimal.Remainder(range, maxValue);
//        }
//
//        private long GenerateBigInt(Column column)
//        {
//            var minValue = long.MinValue;
//            var maxValue = long.MaxValue;
//
//            var buffer = new byte[8];
//            Random.NextBytes(buffer);
//            var range = BitConverter.ToInt64(buffer, 0);
//
//            return Math.Abs(range % (maxValue - minValue)) + minValue;
//        }
//
//        private int GenerateInt(Column column)
//        {
//            if (column.constrains is IntConstrains constrains)
//            {
//                return Random.Next(constrains.MinValue, constrains.MaxValue);
//            }
//
//            return Random.Next();
//        }
//
//        private int GenerateSmallInt(Column column)
//        {
//            var minValue = short.MinValue;
//            var maxValue = short.MaxValue;
//
//            var buffer = new byte[2];
//            Random.NextBytes(buffer);
//            var range = BitConverter.ToInt16(buffer, 0);
//
//            return Math.Abs(range % (maxValue - minValue)) + minValue;
//        }
//
//        private int GenerateTinyInt(Column column)
//        {
//            var minValue = byte.MinValue;
//            var maxValue = byte.MaxValue;
//
//            var buffer = new byte[1];
//            Random.NextBytes(buffer);
//            var range = buffer[0];
//
//            return Math.Abs(range % (maxValue - minValue)) + minValue;
//        }
//
//        private bool GenerateBit(Column column)
//        {
//            return Random.Next(2) == 1;
//        }
    }
}