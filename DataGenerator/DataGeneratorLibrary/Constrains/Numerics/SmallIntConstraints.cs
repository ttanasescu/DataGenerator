namespace DataGeneratorLibrary.Constrains.Numerics
{
    public class SmallIntConstraints : NumericConstraints<short>
    {
        public short MinValue { get; set; } = short.MinValue;
        public short MaxValue { get; set; } = short.MaxValue;

        public SmallIntConstraints()
        {
            MaxPossibleValue = short.MaxValue;
            MinPossibleValue = short.MinValue;
        }
    }
}