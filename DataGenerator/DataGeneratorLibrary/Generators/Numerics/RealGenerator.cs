using DataGeneratorLibrary.Constrains.Numerics;

namespace DataGeneratorLibrary.Generators.Numerics
{
    public class RealGenerator : DataTypeGenerator
    {
        private RealConstrains Constrains { get; set; }

        public RealGenerator(Column column) : base(column)
        {
            if (Column.constrains is RealConstrains constrains)
            {
                Constrains = constrains;
            }
            else
            {
                Constrains = new RealConstrains();
            }
        }

        public override object Generate()
        {
            double minValue = Constrains.MinValue;
            double maxValue = Constrains.MaxValue;

            return (float)(Random.NextDouble() * (maxValue - minValue) + minValue);
        }
    }
}