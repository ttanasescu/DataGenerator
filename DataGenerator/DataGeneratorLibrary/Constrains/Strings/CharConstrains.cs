using DataGeneratorLibrary.Helpers;

namespace DataGeneratorLibrary.Constrains.Strings
{
    public class CharConstrains : StringConstrains
    {
        public override int MinLength
        {
            get => Extensions.Constrain(MaxLengthValue, MinPossibleLength, MaxPossibleLength);
            set => MaxLengthValue = value;
        }

        public CharConstrains(int maxLength) : base(maxLength)
        {
            MaxPossibleLength = 8000;
        }
    }
}