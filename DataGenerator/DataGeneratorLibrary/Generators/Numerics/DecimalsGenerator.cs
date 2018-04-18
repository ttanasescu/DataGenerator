using System;
using System.Data.SqlTypes;
using DataGeneratorLibrary.Constrains.Numerics;

namespace DataGeneratorLibrary.Generators.Numerics
{
    public class DecimalsGenerator : DataTypeGenerator
    {
        private DecimalConstrains Constrains { get; set; }

        public DecimalsGenerator(Column column) : base(column)
        {
            if (Column.constrains is DecimalConstrains constrains)
            {
                Constrains = constrains;
            }
            else
            {
                Constrains = new DecimalConstrains();
            }
        }

        public override object Generate()
        {
            var minValue = Constrains.MinValue;
            var maxValue = Constrains.MaxValue;

            var minValueScale = new SqlDecimal(minValue).Scale;
            var maxValueScale = new SqlDecimal(maxValue).Scale;

            var scale = (byte)(minValueScale + maxValueScale);
            if (scale > 28)
                scale = 28;

            var range = new decimal(Random.Next(), Random.Next(), Random.Next(), false, scale);
            if (Math.Sign(minValue) == Math.Sign(maxValue) || minValue == 0 || maxValue == 0)
                return decimal.Remainder(range, maxValue - minValue) + minValue;

            var isNegativeRange = (double)minValue + Random.NextDouble() * ((double)maxValue - (double)minValue) < 0;
            return isNegativeRange ? decimal.Remainder(range, -minValue) + minValue : decimal.Remainder(range, maxValue);
        }
    }
}