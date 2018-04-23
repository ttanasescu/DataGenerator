namespace DataGeneratorLibrary.Constrains.Numerics
{
    public class IntConstrains : Constrains
    {
        public int MinValue { get; set; }
        public int MaxValue { get; set; } = int.MaxValue;
    }
}