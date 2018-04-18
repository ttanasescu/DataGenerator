using System;

namespace DataGeneratorLibrary.Generators.DateTime
{
    public class TimeGenerator : DataTypeGenerator
    {
        private TimeConstrains Constrains { get; set; }

        public TimeGenerator(Column column) : base(column)
        {
            if (column.constrains is TimeConstrains constrains)
            {
                Constrains = constrains;
            }
            else
            {
                Constrains = new TimeConstrains();
            }
        }

        public override object Generate()
        {
            var minTicks = Constrains.MinTime.Ticks;
            var maxTicks = Constrains.MaxTime.Ticks;

            var buffer = new byte[8];
            Random.NextBytes(buffer);
            var longRandom = BitConverter.ToInt64(buffer, 0);

            var span = new TimeSpan(Math.Abs(longRandom % (maxTicks - minTicks)) + minTicks);

            return new TimeSpan(span.Days, span.Hours, span.Minutes, span.Seconds, span.Milliseconds);
        }
    }
}