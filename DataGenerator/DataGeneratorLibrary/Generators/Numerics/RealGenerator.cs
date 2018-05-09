using DataGeneratorLibrary.Constrains.Numerics;
using DataGeneratorLibrary.DAL;

namespace DataGeneratorLibrary.Generators.Numerics
{
    public class RealGenerator : DataTypeGenerator
    {
        private RealConstraints Constraints { get; set; }

        public RealGenerator(Column column) : base(column)
        {
            if (Column.Constraints is RealConstraints constrains)
            {
                Constraints = constrains;
            }
            else
            {
                Constraints = new RealConstraints();
            }
        }

        public override object Generate()
        {
            double minValue = Constraints.MinValue;
            double maxValue = Constraints.MaxValue;

            return (float)(Random.NextDouble() * (maxValue - minValue) + minValue);
        }
    }
}