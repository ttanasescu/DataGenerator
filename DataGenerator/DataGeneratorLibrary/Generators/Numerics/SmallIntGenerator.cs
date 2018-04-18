using System;
using DataGeneratorLibrary.Constrains.Numerics;

namespace DataGeneratorLibrary.Generators.Numerics
{
    public class SmallIntGenerator : DataTypeGenerator
    {
        private SmallIntConstrains Constrains { get; set; }

        public SmallIntGenerator(Column column) : base(column)
        {
            if (Column.constrains is SmallIntConstrains constrains)
            {
                Constrains = constrains;
            }
        }

        public override object Generate()
        {
            var minValue = Constrains.MinValue;
            var maxValue = Constrains.MaxValue;

            var buffer = new byte[2];
            Random.NextBytes(buffer);
            var range = BitConverter.ToInt16(buffer, 0);

            return Math.Abs(range % (maxValue - minValue)) + minValue;
        }
    }
}