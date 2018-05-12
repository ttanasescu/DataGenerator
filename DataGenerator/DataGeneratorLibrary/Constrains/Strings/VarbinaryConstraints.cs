namespace DataGeneratorLibrary.Constrains.Strings
{
    public class VarbinaryConstraints : VarcharConstraints
    {
        public VarbinaryConstraints(int? maxLength) : base(maxLength)
        {
            MaxPossibleLength = maxLength ?? 8000;
        }
    }
}