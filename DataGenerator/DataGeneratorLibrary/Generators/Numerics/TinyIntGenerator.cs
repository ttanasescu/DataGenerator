using System;
using DataGeneratorLibrary.Constrains.Numerics;

namespace DataGeneratorLibrary.Generators.Numerics
{
    public class TinyIntGenerator : DataTypeGenerator
    {
        private TinyIntConstraints Constraints { get; set; }

        public TinyIntGenerator(Column column) : base(column)
        {
            if (Column.Constraints is TinyIntConstraints constrains)
            {
                Constraints = constrains;
            }
            else
            {
                Constraints = new TinyIntConstraints();
            }
        }

        public override object Generate()
        {
            var minValue = Constraints.MinValue;
            var maxValue = Constraints.MaxValue;

            var buffer = new byte[1];
            Random.NextBytes(buffer);
            var range = buffer[0];

            return Math.Abs(range % (maxValue - minValue)) + minValue;
        }
    }
}