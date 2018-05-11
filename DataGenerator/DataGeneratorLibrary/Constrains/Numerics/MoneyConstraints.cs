using DataGeneratorLibrary.Helpers;

namespace DataGeneratorLibrary.Constrains.Numerics
{
    public class MoneyConstraints : DecimalConstraints
    {
        private decimal _minValue ;
        private decimal _maxValue;

        public override decimal MinValue
        {
            get => _minValue;
            set => _minValue = Extensions.Constrain(value, MinPossibleValue, MaxPossibleValue);
        }

        public override decimal MaxValue
        {
            get => _maxValue;
            set => _maxValue = Extensions.Constrain(value, MinPossibleValue, MaxPossibleValue);
        }

        public MoneyConstraints()
        {
            MinPossibleValue = -922337203685477.5808m;
            MaxPossibleValue = 922337203685477.5807m;
            _maxValue = 20000.001m;
        }

    }
}