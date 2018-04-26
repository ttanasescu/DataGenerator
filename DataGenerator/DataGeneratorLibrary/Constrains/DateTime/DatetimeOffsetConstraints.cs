using System;

namespace DataGeneratorLibrary.Constrains.DateTime
{
    public class DatetimeOffsetConstraints : Constraints
    {
        public DateTimeOffset MinDatetime { get; set; }
        public DateTimeOffset MaxDatetime { get; set; }

        public DateTimeOffset MinPossibleDatetime { get; set; }
        public DateTimeOffset MaxPossibleDatetime { get; set; }
        
        public TimeSpan MinPossibleOffset { get; set; }
        public TimeSpan MaxPossibleOffset { get; set; }

        public DatetimeOffsetConstraints()
        {
            MinDatetime = new DateTimeOffset(System.DateTime.UtcNow);
            MaxDatetime = new DateTimeOffset(System.DateTime.UtcNow);

            MinPossibleDatetime = DateTimeOffset.MinValue;
            MaxPossibleDatetime = DateTimeOffset.MaxValue;

            MinPossibleOffset = new TimeSpan(-12, 0, 0);
            MaxPossibleOffset = new TimeSpan(+14, 0, 0);
        }
    }
}