namespace DataGeneratorLibrary.Constrains.Numerics
{
    public class IntConstraints : NumericConstraints<int>
    {
        public int MinValue { get; set; }
        public int MaxValue { get; set; } = 1000;
        public int IncrementStep { get; set; } = 1;
        public bool UseIncrement { get; set; }

        public IntConstraints()
        {
            MaxPossibleValue = int.MaxValue;
            MinPossibleValue = int.MinValue;
        }
    }
}