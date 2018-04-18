namespace DataGeneratorLibrary.Constrains.Numerics
{
    public class SmallIntConstrains : Constrains
    {
        public short MinValue { get; set; } = short.MinValue;
        public short MaxValue { get; set; } = short.MaxValue;
    }
}