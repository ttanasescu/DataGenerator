using System;
using DataGeneratorLibrary.Constrains.Numerics;
using DataGeneratorLibrary.DAL;

namespace DataGeneratorLibrary.Generators.Numerics
{
    public class SmallIntGenerator : DataTypeGenerator
    {
        private SmallIntConstraints Constraints { get; set; }

        public SmallIntGenerator(Column column) : base(column)
        {
            if (Column.Constraints is SmallIntConstraints constrains)
            {
                Constraints = constrains;
            }
        }

        public override object Generate()
        {
            var minValue = Constraints.MinValue;
            var maxValue = Constraints.MaxValue;

            var buffer = new byte[2];
            Random.NextBytes(buffer);
            var range = BitConverter.ToInt16(buffer, 0);

            return Math.Abs(range % (maxValue - minValue)) + minValue;
        }
    }
}