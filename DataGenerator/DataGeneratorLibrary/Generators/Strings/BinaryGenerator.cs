using DataGeneratorLibrary.Constrains.Strings;
using DataGeneratorLibrary.DAL;

namespace DataGeneratorLibrary.Generators.Strings
{
    public class BinaryGenerator : DataTypeGenerator
    {
        private StringConstraints Constraints { get; set; }

        public BinaryGenerator(Column column) : base(column)
        {
            if (Column.Constraints is StringConstraints constrains)
            {
                Constraints = constrains;
            }
            else
                switch (column.DataType)
                {
                    case TSQLDataType.binary:
                        Constraints = new BinaryConstraints(column.CharMaxLength ?? 1);
                        break;
                    case TSQLDataType.image:
                        Constraints = new ImageConstraints(column.CharMaxLength ?? 1);
                        break;
                    case TSQLDataType.varbinary:
                        Constraints = new VarbinaryConstraints(column.CharMaxLength ?? 1);
                        break;
                    default:
                        Constraints = new StringConstraints(column.CharMaxLength ?? 1);
                        break;
                }
        }

        public override object Generate()
        {
            var lenght = Random.Next(Constraints.MinLength, Constraints.MaxLength + 1);

            var buffer = new byte[lenght];
            Random.NextBytes(buffer);

            return buffer;
        }
    }
}