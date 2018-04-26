using DataGeneratorLibrary.Constrains.Numerics;

namespace DataGeneratorLibrary.Generators.Numerics
{
    public class IntGenerator : DataTypeGenerator
    {
        private IntConstraints Constraints { get; set; }

        public IntGenerator(Column column) : base(column)
        {
            if (Column.Constraints is IntConstraints constrains)
            {
                Constraints = constrains;
            }
            else
            {
                Constraints = new IntConstraints();
            }
        }

        public override object Generate()
        {
            return Random.Next(Constraints.MinValue, Constraints.MaxValue);
        }
    }
}