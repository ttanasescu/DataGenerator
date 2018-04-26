namespace DataGeneratorLibrary.Constrains.Strings
{
    public class NtextConstraints : VarcharConstraints
    {
        public NtextConstraints(int maxLength = 50) : base(maxLength)
        {
            MaxPossibleLength = 1073741823;
        }
    }
}