namespace DataGeneratorLibrary.Constrains.Numerics
{
    public class IntConstrains : NumericConstrains<int>
    {
        public int MinValue { get; set; }
        public int MaxValue { get; set; } = int.MaxValue;

        public IntConstrains()
        {
            MaxPossibleValue = int.MaxValue;
            MinPossibleValue = int.MinValue;
        }
    }
}