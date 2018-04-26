namespace DataGeneratorLibrary.Constrains.Numerics
{
    public class FloatConstrains : NumericConstrains<double>
    {
        public double MinValue { get; set; } = double.MinValue;
        public double MaxValue { get; set; } = double.MaxValue;

        public FloatConstrains()
        {
            MaxPossibleValue = double.MaxValue;
            MinPossibleValue = double.MinValue;
        }
    }
}