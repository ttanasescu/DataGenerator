using DataGeneratorLibrary.Constrains.DateTime;
using DataGeneratorLibrary.DAL;

namespace DataGeneratorLibrary.Generators.DateTime
{
    public class DateGenerator : DataTypeGenerator
    {
        private DateConstraints DateConstraints { get; }

        public DateGenerator(Column column) : base(column)
        {
            if (column.Constraints is DateConstraints constrains)
            {
                DateConstraints = constrains;
            }
            else
            {
                DateConstraints = new DateConstraints();
            }
        }

        public override object Generate()
        {
            var range = (DateConstraints.MaxDate - DateConstraints.MinDate).Days;

            return DateConstraints.MinDate.AddDays(Random.Next(range));
        }
    }
}