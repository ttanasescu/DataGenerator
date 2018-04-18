namespace DataGeneratorLibrary.Constrains.Numerics
{
    public class SmallMoneyConstrains : DecimalConstrains
    {
        private decimal _minValue = -214748.3648m;
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
    }
}