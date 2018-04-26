namespace DataGeneratorLibrary.Constrains.Numerics
{
    public class TinyIntConstraints : NumericConstraints<byte>
    {
        public byte MinValue { get; set; }
        public byte MaxValue { get; set; } = byte.MaxValue;

        public TinyIntConstraints()
        {
            MinPossibleValue = byte.MinValue;
            MaxPossibleValue = byte.MaxValue;
        }
    }
}