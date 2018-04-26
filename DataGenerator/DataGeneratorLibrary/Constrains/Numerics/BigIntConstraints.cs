namespace DataGeneratorLibrary.Constrains.Numerics
{
    public class BigIntConstraints : NumericConstraints<long>
    {
        public long MinValue { get; set; } = long.MinValue;
        public long MaxValue { get; set; } = long.MaxValue;

        public BigIntConstraints()
        {
            MaxPossibleValue = long.MaxValue;
            MinPossibleValue = long.MinValue;
        }
    }
}