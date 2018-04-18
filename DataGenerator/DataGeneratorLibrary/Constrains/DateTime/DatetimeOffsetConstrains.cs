using System;

namespace DataGeneratorLibrary.Constrains.DateTime
{
    public class DatetimeOffsetConstrains : Constrains
    {
        public DateTimeOffset MinDatetime { get; set; }
        public DateTimeOffset MaxDatetime { get; set; }

        public TimeSpan MinOffset { get; set; }
        public TimeSpan MaxOffset { get; set; }

        public DatetimeOffsetConstrains()
        {
            MinOffset = new TimeSpan(-14, 0, 0);
            MaxOffset = new TimeSpan(14, 0, 0);

            MinDatetime = new DateTimeOffset(System.DateTime.MinValue, MinOffset);
            MaxDatetime = new DateTimeOffset(System.DateTime.MaxValue, MaxOffset);
        }
    }
}