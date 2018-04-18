namespace DataGeneratorLibrary.Generators.Numerics
{
    public class IntGenerator : DataTypeGenerator
    {
        private IntConstrains Constrains { get; set; }

        public IntGenerator(Column column) : base(column)
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
            return Random.Next(Constrains.MinValue, Constrains.MaxValue);
        }
    }
}