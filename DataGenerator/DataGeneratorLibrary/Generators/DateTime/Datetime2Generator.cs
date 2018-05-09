using System;
using DataGeneratorLibrary.Constrains.DateTime;
using DataGeneratorLibrary.DAL;

namespace DataGeneratorLibrary.Generators.DateTime
{
    public class Datetime2Generator : DataTypeGenerator
    {
        private Datetime2Constraints Constraints { get; set; }

        public Datetime2Generator(Column column) : base(column)
        {
            if (column.Constraints is Datetime2Constraints constrains)
            {
                Constraints = constrains;
            }
            else if (column.DataType == TSQLDataType.datetime)
            {
                Constraints = new DatetimeConstraints();
            }
            else if (column.DataType == TSQLDataType.smallint)
            {
                Constraints = new SmallDatetimeConstraints();
            }
            else
            {
                Constraints = new Datetime2Constraints();
            }
        }

        public override object Generate()
        {
            var minTicks = Constraints.MinDatetime.Ticks;
            var maxTicks = Constraints.MaxDatetime.Ticks;

            if (minTicks == maxTicks)
            {
                return new System.DateTime(minTicks);
            }

            var buffer = new byte[8];
            Random.NextBytes(buffer);
            var longRandom = BitConverter.ToInt64(buffer, 0);

            return new System.DateTime(Math.Abs(longRandom % (maxTicks - minTicks)) + minTicks);
        }
    }
}