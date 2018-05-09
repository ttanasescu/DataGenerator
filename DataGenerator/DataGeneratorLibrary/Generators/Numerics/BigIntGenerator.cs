using System.Numerics;
using DataGeneratorLibrary.Constrains.Numerics;
using DataGeneratorLibrary.DAL;

namespace DataGeneratorLibrary.Generators.Numerics
{
    public class BigIntGenerator : DataTypeGenerator
    {
        private BigIntConstraints Constraints { get; set; }

        public BigIntGenerator(Column column) : base(column)
        {
            if (Column.Constraints is BigIntConstraints constrains)
            {
                Constraints = constrains;
            }
            else
            {
                Constraints = new BigIntConstraints();
            }
        }

        public override object Generate()
        {
            var minValue = new BigInteger(Constraints.MinValue);
            var maxValue = new BigInteger(Constraints.MaxValue);

            var buffer = new byte[8];
            Random.NextBytes(buffer);
            var randomBigInt = BigInteger.Abs(new BigInteger(buffer));
            
            return (long)(BigInteger.Abs(randomBigInt % (maxValue - minValue)) + minValue); ;
        }
    }
}