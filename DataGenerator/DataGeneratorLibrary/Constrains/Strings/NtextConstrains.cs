namespace DataGeneratorLibrary.Constrains.Strings
{
    public class NtextConstrains : VarcharConstrains
    {
        public NtextConstrains(int maxLength = 50) : base(maxLength)
        {
            MaxPossibleLength = 1073741823;
        }
    }
}