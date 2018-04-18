using DataGeneratorLibrary.Constrains.Numerics;

namespace DataGeneratorLibrary.Generators.Numerics
{
    public class FloatGenerator : DataTypeGenerator
    {
        private FloatConstrains Constrains { get; set; }

        public FloatGenerator(Column column) : base(column)
        {
            if (Column.constrains is FloatConstrains constrains)
            {
                Constrains = constrains;
            }
            else
            {
                Constrains = new FloatConstrains();
            }
        }

        public override object Generate()
        {
            var minValue = Constrains.MinValue;
            var maxValue = Constrains.MaxValue;

            return Random.NextDouble() * (maxValue - minValue) + minValue;
        }
    }
}