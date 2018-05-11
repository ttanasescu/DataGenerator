using DataGeneratorLibrary.Helpers;

namespace DataGeneratorLibrary.Constrains.Numerics
{
    public class SmallMoneyConstraints : DecimalConstraints
    {
        private decimal _minValue;
        private decimal _maxValue;

        public override decimal MinValue
        {
            get => _minValue;
            set => _minValue = Extensions.Constrain(value, MinPossibleValue, MaxPossibleValue);
        }

        public override decimal MaxValue
        {
            get => _maxValue;
            set => _minValue = Extensions.Constrain(value, MinPossibleValue, MaxPossibleValue);
        }

        public SmallMoneyConstraints()
        {
            MinPossibleValue = -214748.3648m;
            MaxPossibleValue = 214748.3647m;
            _maxValue = 214748.3647m;
        }
    }
}