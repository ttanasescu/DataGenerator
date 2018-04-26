namespace DataGeneratorLibrary.Constrains.Strings
{
    public class VarcharConstraints : StringConstraints
    {
        public VarcharConstraints(int maxLength) : base(maxLength)
        {
            MaxPossibleLength = 8000;
        }
    }
}