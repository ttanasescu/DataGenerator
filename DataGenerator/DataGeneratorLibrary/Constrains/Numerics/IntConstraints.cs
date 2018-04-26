namespace DataGeneratorLibrary.Constrains.Numerics
{
    public class IntConstraints : NumericConstraints<int>
    {
        public int MinValue { get; set; }
        public int MaxValue { get; set; } = 1000;

        public IntConstraints()
        {
            MaxPossibleValue = int.MaxValue;
            MinPossibleValue = int.MinValue;
        }
    }
}