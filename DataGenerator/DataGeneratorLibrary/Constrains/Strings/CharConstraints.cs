using DataGeneratorLibrary.Helpers;

namespace DataGeneratorLibrary.Constrains.Strings
{
    public class CharConstraints : StringConstraints
    {
        public override int MinLength
        {
            get => Extensions.Constrain(MaxLengthValue, MinPossibleLength, MaxPossibleLength);
            set => MaxLengthValue = value;
        }

        public CharConstraints(int? maxLength) : base(maxLength)
        {
        }

        public CharConstraints()
        {
        }
    }
}