namespace DataGeneratorLibrary.Constrains.Numerics
{
    public class SmallIntConstrains : NumericConstrains<short>
    {
        public short MinValue { get; set; } = short.MinValue;
        public short MaxValue { get; set; } = short.MaxValue;

        public SmallIntConstrains()
        {
            MaxPossibleValue = short.MaxValue;
            MinPossibleValue = short.MinValue;
        }
    }
}