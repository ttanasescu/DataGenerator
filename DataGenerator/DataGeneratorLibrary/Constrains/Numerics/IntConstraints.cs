namespace DataGeneratorLibrary.Constrains.Numerics
{
    public class IntConstraints : NumericConstraints<int>
    {
        public int MinValue { get; set; }
        public int MaxValue { get; set; } = int.MaxValue;

        public IntConstraints()
        {
            MaxPossibleValue = int.MaxValue;
            MinPossibleValue = int.MinValue;
        }
    }
}