namespace DataGeneratorLibrary.Constrains.Strings
{
    public class NtextConstraints : VarcharConstraints
    {
        public NtextConstraints(int? maxLength) : base(maxLength)
        {
            MaxPossibleLength = maxLength ?? 1073741823;
        }
    }
}