namespace DataGeneratorLibrary.Constrains.Strings
{
    public class VarcharConstrains : StringConstrains
    {
        public VarcharConstrains(int maxLength) : base(maxLength)
        {
            MaxPossibleLength = 8000;
        }
    }
}