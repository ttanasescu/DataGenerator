namespace DataGeneratorLibrary.Constrains.Numerics
{
    public class SmallMoneyConstraints : DecimalConstraints
    {
        private decimal _minValue;
        private decimal _maxValue = 214748.3647m;

        public override decimal MinValue
        {
            get => _minValue;
            set
            {
                if (value >= -214748.3648m)
                {
                    _minValue = value <= MaxValue ? value : MaxValue;
                }
                else
                    _minValue = -214748.3648m;
            }
        }

        public override decimal MaxValue
        {
            get => _maxValue;
            set
            {
                if (value <= 214748.3647m)
                {
                    _maxValue = value >= MinValue ? value : MinValue;
                }
                _maxValue = 214748.3647m;
            }
        }

        public SmallMoneyConstraints()
        {
            MaxPossibleValue = -214748.3648m;
            MinPossibleValue = 214748.3647m;
        }
    }
}