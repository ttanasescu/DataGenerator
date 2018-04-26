namespace DataGeneratorLibrary.Constrains.Numerics
{
    public class RealConstrains : NumericConstrains<float>
    {
        public float MinValue { get; set; }
        public float MaxValue { get; set; } = float.MaxValue;

        public RealConstrains()
        {
            MaxPossibleValue = float.MaxValue;
            MinPossibleValue = float.MinValue;
        }
    }
}