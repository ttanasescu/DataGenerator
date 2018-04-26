using DataGeneratorLibrary.Helpers;

namespace DataGeneratorLibrary.Constrains.Strings
{
    public class StringConstraints : Constraints
    {
        protected int MinLengthValue = 1;
        protected int MaxLengthValue;

        protected int MinPossibleLength = 1;
        protected int MaxPossibleLength = int.MaxValue;

        public int MaxLength
        {
            get => Extensions.Constrain(MaxLengthValue, MinPossibleLength, MaxPossibleLength);
            set => MaxLengthValue = value;
        }

        public virtual int MinLength
        {
            get => Extensions.Constrain(MinLengthValue, MinPossibleLength, MaxPossibleLength);
            set => MinLengthValue = value;
        }

        public StringConstraints(int maxLength)
        {
            MaxLength = maxLength;
        }
    }
}