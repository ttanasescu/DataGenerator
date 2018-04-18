using DataGeneratorLibrary.Constrains.Numerics;

namespace DataGeneratorLibrary.Generators.Numerics
{
    public class BitGenerator : DataTypeGenerator
    {
        private IntConstrains Constrains { get; set; }

        public BitGenerator(Column column) : base(column)
        {
            if (Column.constrains is IntConstrains constrains)
            {
                Constrains = constrains;
            }
            else
            {
                Constrains = new IntConstrains();
            }
        }

        public override object Generate()
        {
            return Random.Next(2) == 1;
        }
    }
}