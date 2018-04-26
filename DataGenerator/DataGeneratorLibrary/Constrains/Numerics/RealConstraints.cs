namespace DataGeneratorLibrary.Constrains.Numerics
{
    public class RealConstraints : NumericConstraints<float>
    {
        public float MinValue { get; set; }
        public float MaxValue { get; set; } = (float) decimal.MaxValue/2;

        public RealConstraints()
        {
            MaxPossibleValue = (float) decimal.MaxValue/2; //TODO Set as float
            MinPossibleValue = (float) decimal.MinValue/2;
        }
    }
}