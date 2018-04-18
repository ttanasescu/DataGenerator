namespace DataGeneratorLibrary.Constrains.Numerics
{
    public class MoneyConstrains : DecimalConstrains
    {
        private decimal _minValue = -922337203685477.5808m;
        private decimal _maxValue = 922337203685477.5807m;

        public override decimal MinValue
        {
            get => _minValue;
            set
            {
                if (value >= -922337203685477.5808m)
                {
                    _minValue = value <= MaxValue ? value : MaxValue;
                }
                else
                    _minValue = -922337203685477.5808m;
            }
        }

        public override decimal MaxValue
        {
            get => _maxValue;
            set
            {
                if (value <= 922337203685477.5807m)
                {
                    _maxValue = value >= MinValue ? value : MinValue;
                }

                _maxValue = 922337203685477.5807m;
            }
        }
    }
}