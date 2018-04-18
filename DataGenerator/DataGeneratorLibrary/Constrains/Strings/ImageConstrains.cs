namespace DataGeneratorLibrary.Constrains.Strings
{
    public class ImageConstrains : VarcharConstrains
    {
        public ImageConstrains(int maxLength = 50) : base(maxLength)
        {
            MaxPossibleLength = 2147483647;
        }
    }
}