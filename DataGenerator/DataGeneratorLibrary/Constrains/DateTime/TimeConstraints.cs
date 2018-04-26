using System;

namespace DataGeneratorLibrary.Constrains.DateTime
{
    public class TimeConstraints : Constraints
    {
        public TimeSpan MinTime { get; set; } = new TimeSpan(0, 0, 0, 0, 0);
        public TimeSpan MaxTime { get; set; } = new TimeSpan(0, 23, 59, 59, 9999999);
    }
}