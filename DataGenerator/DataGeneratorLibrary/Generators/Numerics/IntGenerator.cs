using System;
using DataGeneratorLibrary.Constrains.Numerics;
using DataGeneratorLibrary.DAL;

namespace DataGeneratorLibrary.Generators.Numerics
{
    public class IntGenerator : DataTypeGenerator
    {
        private IntConstraints Constraints { get; set; }
        private int _currentValue;

        public IntGenerator(Column column) : base(column)
        {
            if (Column.Constraints is IntConstraints constrains)
            {
                Constraints = constrains;
                _currentValue = Constraints.MinValue;
            }
            else
            {
                Constraints = new IntConstraints();
            }
        }

        public override object Generate()
        {
            if (Constraints.UseIncrement)
            {
                return GenerateIncremented();
            }
            return GenerateRandom();
        }

        private int GenerateIncremented()
        {
            var tempValue = _currentValue;
            try
            {
                _currentValue += Constraints.IncrementStep;
            }
            catch (OverflowException)
            {
                _currentValue = int.MaxValue;
            }
            return tempValue;
        }

        private object GenerateRandom()
        {
            return Random.Next(Constraints.MinValue, Constraints.MaxValue + 1);
        }
    }
}