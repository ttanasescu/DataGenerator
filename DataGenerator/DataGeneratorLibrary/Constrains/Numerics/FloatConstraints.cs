namespace DataGeneratorLibrary.Constrains.Numerics
{
    public class FloatConstraints : NumericConstraints<double>
    {
        public double MinValue { get; set; }
        public double MaxValue { get; set; } = (double) decimal.MaxValue/2;

        public FloatConstraints()
        {
            MaxPossibleValue = (double) decimal.MaxValue/2; //TODO Set as double
            MinPossibleValue = (double) decimal.MinValue/2;
        }
    }
}