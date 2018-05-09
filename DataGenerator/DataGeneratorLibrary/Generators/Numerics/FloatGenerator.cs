using DataGeneratorLibrary.Constrains.Numerics;
using DataGeneratorLibrary.DAL;

namespace DataGeneratorLibrary.Generators.Numerics
{
    public class FloatGenerator : DataTypeGenerator
    {
        private FloatConstraints Constraints { get; set; }

        public FloatGenerator(Column column) : base(column)
        {
            if (Column.Constraints is FloatConstraints constrains)
            {
                Constraints = constrains;
            }
            else
            {
                Constraints = new FloatConstraints();
            }
        }

        public override object Generate()
        {
            var minValue = Constraints.MinValue;
            var maxValue = Constraints.MaxValue;

            return Random.NextDouble() * (maxValue - minValue) + minValue;
        }
    }
}