using System;
using DataGeneratorLibrary.Constrains.DateTime;
using DataGeneratorLibrary.DAL;

namespace DataGeneratorLibrary.Generators.DateTime
{
    public class SmallDatetimeGenerator : DataTypeGenerator
    {
        private SmallDatetimeConstraints Constraints { get; set; }

        public SmallDatetimeGenerator(Column column) : base(column)
        {
            if (column.Constraints is SmallDatetimeConstraints constrains)
            {
                Constraints = constrains;
            }
            else
            {
                Constraints = new SmallDatetimeConstraints();
            }
        }

        public override object Generate()
        {
            var minTicks = Constraints.MinDatetime.Ticks;
            var maxTicks = Constraints.MaxDatetime.Ticks;

            var buffer = new byte[8];
            Random.NextBytes(buffer);
            var longRandom = BitConverter.ToInt64(buffer, 0);

            var dt = new System.DateTime(Math.Abs(longRandom % (maxTicks - minTicks)) + minTicks);

            return new System.DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second);

            //            var range = (Constrains.MaxDatetime - Constrains.MinDatetime).Minutes;
            //            return Constrains.MinDatetime.AddMinutes(Random.Next(range));
            //
            //            var minTicks = Constrains.MinDatetime.Ticks;
            //            var maxTicks = Constrains.MaxDatetime.Ticks;
            //
            //            var buffer = new byte[8];
            //            Random.NextBytes(buffer);
            //            var longRandom = BitConverter.ToInt64(buffer, 0);
            //
            //            return new DateTime(Math.Abs(longRandom % (maxTicks - minTicks)) + minTicks);
        }
    }
}