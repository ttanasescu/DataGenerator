namespace DataGeneratorLibrary.Constrains.Numerics
{
    public class TinyIntConstrains : Constrains
    {
        public byte MinValue { get; set; } = byte.MinValue;
        public byte MaxValue { get; set; } = byte.MaxValue;
    }
}