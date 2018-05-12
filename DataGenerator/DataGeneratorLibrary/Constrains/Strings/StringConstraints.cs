using DataGeneratorLibrary.Helpers;

namespace DataGeneratorLibrary.Constrains.Strings
{
    public class StringConstraints : Constraints
    {
        protected int MinLengthValue = 1;
        protected int MaxLengthValue = 10;

        public int MinPossibleLength { get; } = 1;
        public int MaxPossibleLength { get; set; } = 8000;

        public int MaxLength
        {
            get => MaxLengthValue;
            set => MaxLengthValue = Extensions.Constrain(value, MinPossibleLength, MaxPossibleLength);
        }

        public virtual int MinLength
        {
            get => MinLengthValue;
            set => MinLengthValue = Extensions.Constrain(value, MinPossibleLength, MaxPossibleLength);
        }

        public StringConstraints(int? maxLength)
        {
            MaxPossibleLength = Extensions.Constrain(maxLength ?? MaxPossibleLength, MinPossibleLength, MaxPossibleLength);
            //MaxLength = MaxPossibleLength;
        }

        public StringConstraints()
        {
        }
    }
}