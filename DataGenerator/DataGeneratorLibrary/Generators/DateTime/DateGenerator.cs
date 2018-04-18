using DataGeneratorLibrary.Constrains.DateTime;

namespace DataGeneratorLibrary.Generators.DateTime
{
    public class DateGenerator : DataTypeGenerator
    {
        private DateConstrains DateConstrains { get; }

        public DateGenerator(Column column) : base(column)
        {
            if (column.constrains is DateConstrains constrains)
            {
                DateConstrains = constrains;
            }
            else
            {
                DateConstrains = new DateConstrains();
            }
        }

        public override object Generate()
        {
            var range = (DateConstrains.MaxDate - DateConstrains.MinDate).Days;

            return DateConstrains.MinDate.AddDays(Random.Next(range));
        }
    }
}