using DataGeneratorLibrary.Helpers;

namespace DataGeneratorLibrary.Constrains.Strings
{
    public class StringConstraints : Constraints
    {
        protected int MinLengthValue = 1;
        protected int MaxLengthValue = 8000;

        public int MinPossibleLength { get; } = 1;
        public int MaxPossibleLength { get; set; } = 8000;

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

        public StringConstraints(int? maxLength)
        {
            MaxPossibleLength = Extensions.Constrain(maxLength ?? MaxPossibleLength, MinPossibleLength, MaxPossibleLength);
            MaxLength = MaxPossibleLength;
        }

        public StringConstraints()
        {
        }
    }
}