namespace DataGeneratorLibrary.Constrains.Numerics
{
    public class TinyIntConstrains : NumericConstrains<byte>
    {
        public byte MinValue { get; set; }
        public byte MaxValue { get; set; } = byte.MaxValue;

        public TinyIntConstrains()
        {
            MinPossibleValue = byte.MinValue;
            MaxPossibleValue = byte.MaxValue;
        }
    }
}