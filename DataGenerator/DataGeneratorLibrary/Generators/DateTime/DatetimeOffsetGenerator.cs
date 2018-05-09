using System;
using DataGeneratorLibrary.Constrains.DateTime;
using DataGeneratorLibrary.DAL;

namespace DataGeneratorLibrary.Generators.DateTime
{
    //TODO: Check precissions
    public class DatetimeOffsetGenerator : DataTypeGenerator
    {
        private DatetimeOffsetConstraints Constraints { get; set; }

        public DatetimeOffsetGenerator(Column column) : base(column)
        {
            if (column.Constraints is DatetimeOffsetConstraints constrains)
            {
                Constraints = constrains;
            }
            else
            {
                Constraints = new DatetimeOffsetConstraints();
            }
        }

        public override object Generate()
        {
            var minTicks = Constraints.MinDatetime.UtcTicks;
            var maxTicks = Constraints.MaxDatetime.UtcTicks;

            if (minTicks == maxTicks)
            {
                return new DateTimeOffset(minTicks, TimeSpan.Zero);
            }

            var buffer = new byte[8];
            Random.NextBytes(buffer);
            var longRandom = BitConverter.ToInt64(buffer, 0);

            var offset = GenerateOffset();

            return new DateTimeOffset(Math.Abs(longRandom % (maxTicks - minTicks)) + minTicks, offset);
        }

        private TimeSpan GenerateOffset()
        {
            var minTicks = Constraints.MinDatetime.Offset.Ticks;
            var maxTicks = Constraints.MaxDatetime.Offset.Ticks;

            if (minTicks == maxTicks)
            {
                return new TimeSpan(minTicks);
            }

            var buffer = new byte[8];
            Random.NextBytes(buffer);
            var longRandom = BitConverter.ToInt64(buffer, 0);

            var ts =  new TimeSpan(Math.Abs(longRandom % (maxTicks - minTicks)) + minTicks);
            return new TimeSpan(ts.Hours, ts.Minutes, 0);
        }
    }
}