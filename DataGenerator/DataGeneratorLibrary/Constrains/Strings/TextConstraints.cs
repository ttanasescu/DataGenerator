namespace DataGeneratorLibrary.Constrains.Strings
{
    public class TextConstraints : VarcharConstraints
    {
        public TextConstraints(int? maxLength) : base(maxLength)
        {
            MaxPossibleLength = maxLength ?? 2147483647;
        }
    }
}