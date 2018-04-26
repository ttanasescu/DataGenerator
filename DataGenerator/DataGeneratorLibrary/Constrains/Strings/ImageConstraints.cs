namespace DataGeneratorLibrary.Constrains.Strings
{
    public class ImageConstraints : VarcharConstraints
    {
        public ImageConstraints(int maxLength = 50) : base(maxLength)
        {
            MaxPossibleLength = 2147483647;
        }
    }
}