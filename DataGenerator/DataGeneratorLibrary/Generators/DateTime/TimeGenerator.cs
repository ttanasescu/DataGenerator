using System;
using DataGeneratorLibrary.Constrains.DateTime;
using DataGeneratorLibrary.DAL;

namespace DataGeneratorLibrary.Generators.DateTime
{
    public class TimeGenerator : DataTypeGenerator
    {
        private TimeConstraints Constraints { get; set; }

        public TimeGenerator(Column column) : base(column)
        {
            if (column.Constraints is TimeConstraints constrains)
            {
                Constraints = constrains;
            }
            else
            {
                Constraints = new TimeConstraints();
            }
        }

        public override object Generate()
        {
            var minTicks = Constraints.MinTime.Ticks;
            var maxTicks = Constraints.MaxTime.Ticks;

            if (minTicks == maxTicks)
            {
                return minTicks;
            }

            var buffer = new byte[8];
            Random.NextBytes(buffer);
            var longRandom = BitConverter.ToInt64(buffer, 0);

            var span = new TimeSpan(Math.Abs(longRandom % (maxTicks - minTicks)) + minTicks);

            return new TimeSpan(span.Days, span.Hours, span.Minutes, span.Seconds, span.Milliseconds);
        }
    }
}