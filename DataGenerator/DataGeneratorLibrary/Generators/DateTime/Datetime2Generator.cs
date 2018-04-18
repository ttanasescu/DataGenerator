using System;
using DataGeneratorLibrary.Constrains.DateTime;

namespace DataGeneratorLibrary.Generators.DateTime
{
    public class Datetime2Generator : DataTypeGenerator
    {
        private Datetime2Constrains Constrains { get; set; }

        public Datetime2Generator(Column column) : base(column)
        {
            if (column.constrains is Datetime2Constrains constrains)
            {
                Constrains = constrains;
            }
            else if (column.DataType == TSQLDataType.datetime)
            {
                Constrains = new DatetimeConstrains();
            }
            else if (column.DataType == TSQLDataType.smallint)
            {
                Constrains = new SmallDatetimeConstrains();
            }
            else
            {
                Constrains = new Datetime2Constrains();
            }
        }

        public override object Generate()
        {
            var minTicks = Constrains.MinDatetime.Ticks;
            var maxTicks = Constrains.MaxDatetime.Ticks;

            var buffer = new byte[8];
            Random.NextBytes(buffer);
            var longRandom = BitConverter.ToInt64(buffer, 0);

            return new System.DateTime(Math.Abs(longRandom % (maxTicks - minTicks)) + minTicks);
        }
    }
}