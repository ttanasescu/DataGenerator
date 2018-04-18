namespace DataGeneratorLibrary.Constrains.Strings
{
    public class TextConstrains : VarcharConstrains
    {
        public TextConstrains(int maxLength = 50) : base(maxLength)
        {
            MaxPossibleLength = 2147483647;
        }
    }
}