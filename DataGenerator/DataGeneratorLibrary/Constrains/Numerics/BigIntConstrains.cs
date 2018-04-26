namespace DataGeneratorLibrary.Constrains.Numerics
{
    public class BigIntConstrains : NumericConstrains<long>
    {
        public long MinValue { get; set; } = long.MinValue;
        public long MaxValue { get; set; } = long.MaxValue;

        public BigIntConstrains()
        {
            MaxPossibleValue = long.MaxValue;
            MinPossibleValue = long.MinValue;
        }
    }
}