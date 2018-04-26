using DataGeneratorLibrary.Constrains.Numerics;

namespace DataGeneratorLibrary.Generators.Numerics
{
    public class BitGenerator : DataTypeGenerator
    {
        private IntConstraints Constraints { get; set; }

        public BitGenerator(Column column) : base(column)
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
            return Random.Next(2) == 1;
        }
    }
}