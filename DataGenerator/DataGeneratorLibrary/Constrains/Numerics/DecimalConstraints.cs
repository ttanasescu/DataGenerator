using System;

namespace DataGeneratorLibrary.Constrains.Numerics
{
    public class DecimalConstraints : NumericConstraints<decimal>
    {
        private decimal _minValue;
        private decimal _maxValue;

        public virtual decimal MinValue
        {
            get => _minValue;
            set => _minValue = value;
        }

        public virtual decimal MaxValue
        {
            get => _maxValue;
            set => _maxValue = value;
        }

        public DecimalConstraints(byte precision, int scale)
        {
            _maxValue = 10000.100m;
            if (precision > 38 || precision < 0)
            {
                throw new ArgumentOutOfRangeException(precision.ToString());
            }

            if (scale < 0 || scale > precision)
            {
                throw new ArgumentOutOfRangeException(scale.ToString());
            }

            var maxValueString = $"{new string('9', precision - scale)}.{new string('9', scale)}";

            decimal.TryParse(maxValueString, out var maxValue);
            _minValue = decimal.Negate(maxValue);
            _maxValue = maxValue;

            MaxPossibleValue = decimal.MaxValue;
            MinPossibleValue = decimal.MinValue;
        }

        public DecimalConstraints()
        {
            MaxPossibleValue = decimal.MaxValue;
            MinPossibleValue = decimal.MinValue;
            _maxValue = 10000.100m;
        }
    }
}