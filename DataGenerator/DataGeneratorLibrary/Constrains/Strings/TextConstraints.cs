namespace DataGeneratorLibrary.Constrains.Strings
{
    public class TextConstraints : VarcharConstraints
    {
        public TextConstraints(int maxLength = 50) : base(maxLength)
        {
            MaxPossibleLength = 2147483647;
        }
    }
}