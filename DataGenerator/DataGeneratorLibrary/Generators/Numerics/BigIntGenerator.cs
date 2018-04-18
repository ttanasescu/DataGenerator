using System;
using System.Linq;
using System.Numerics;

namespace DataGeneratorLibrary.Generators.Numerics
{
    public class BigIntGenerator : DataTypeGenerator
    {
        private BigIntConstrains Constrains { get; set; }

        public BigIntGenerator(Column column) : base(column)
        {
            if (Column.constrains is BigIntConstrains constrains)
            {
                Constrains = constrains;
            }
            else
            {
                Constrains = new BigIntConstrains();
            }
        }

//        public  object Generate()
//        {
//            var minValue = Constrains.MinValue;
//            var maxValue = Constrains.MaxValue;
//            
//            var buffer = new byte[8];
//            Random.NextBytes(buffer);
//            var range = BitConverter.ToInt64(buffer, 0);
//
//            return Math.Abs(range % (maxValue - minValue)) + minValue;
//        }

        public override object Generate()
        {
            var minValue = new BigInteger(Constrains.MinValue);
            var maxValue = new BigInteger(Constrains.MaxValue);

            var buffer = new byte[8];
            Random.NextBytes(buffer);
            var randomBigInt = BigInteger.Abs(new BigInteger(buffer));
            
            return (long)(BigInteger.Abs(randomBigInt % (maxValue - minValue)) + minValue); ;
        }
    }
}