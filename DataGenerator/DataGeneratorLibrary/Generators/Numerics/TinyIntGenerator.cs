using System;
using DataGeneratorLibrary.Constrains.Numerics;

namespace DataGeneratorLibrary.Generators.Numerics
{
    public class TinyIntGenerator : DataTypeGenerator
    {
        private TinyIntConstrains Constrains { get; set; }

        public TinyIntGenerator(Column column) : base(column)
        {
            if (Column.constrains is TinyIntConstrains constrains)
            {
                Constrains = constrains;
            }
            else
            {
                Constrains = new TinyIntConstrains();
            }
        }

        public override object Generate()
        {
            var minValue = Constrains.MinValue;
            var maxValue = Constrains.MaxValue;

            var buffer = new byte[1];
            Random.NextBytes(buffer);
            var range = buffer[0];

            return Math.Abs(range % (maxValue - minValue)) + minValue;
        }
    }
}