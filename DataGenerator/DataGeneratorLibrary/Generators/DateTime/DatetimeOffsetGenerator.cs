using System;

namespace DataGeneratorLibrary.Generators.DateTime
{
    //TODO: Check precissions
    public class DatetimeOffsetGenerator : DataTypeGenerator
    {
        private DatetimeOffsetConstrains Constrains { get; set; }

        public DatetimeOffsetGenerator(Column column) : base(column)
        {
            if (column.constrains is DatetimeOffsetConstrains constrains)
            {
                Constrains = constrains;
            }
            else
            {
                Constrains = new DatetimeOffsetConstrains();
            }
        }

        public override object Generate()
        {
            var minTicks = Constrains.MinDatetime.Ticks;
            var maxTicks = Constrains.MaxDatetime.Ticks;

            var buffer = new byte[8];
            Random.NextBytes(buffer);
            var longRandom = BitConverter.ToInt64(buffer, 0);

            var offset = GenerateOffset();

            return new DateTimeOffset(Math.Abs(longRandom % (maxTicks - minTicks)) + minTicks, offset);
        }

        private TimeSpan GenerateOffset()
        {
            var minTicks = Constrains.MinOffset.Ticks;
            var maxTicks = Constrains.MaxOffset.Ticks;

            var buffer = new byte[8];
            Random.NextBytes(buffer);
            var longRandom = BitConverter.ToInt64(buffer, 0);

            var ts =  new TimeSpan(Math.Abs(longRandom % (maxTicks - minTicks)) + minTicks);
            return new TimeSpan(ts.Hours, ts.Minutes, 0);
        }
    }
}