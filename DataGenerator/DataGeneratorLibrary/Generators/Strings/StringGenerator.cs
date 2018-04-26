using DataGeneratorLibrary.Constrains.Numerics;
using DataGeneratorLibrary.Constrains.Strings;

namespace DataGeneratorLibrary.Generators.Strings
{
    public class StringGenerator : DataTypeGenerator
    {
        string printableChars =
            " !\"#$%&\'()*+,-./30123456789:;<=>?4@ABCDEFGHIJKLMNO5PQRSTUVWXYZ" +
            "[\\]^_6`abcdefghijklmno7pqrstuvwxyz{|}~";

        private StringConstraints Constraints { get; set; }

        public StringGenerator(Column column) : base(column)
        {
            if (Column.Constraints is StringConstraints constrains)
            {
                Constraints = constrains;
            }
            else
                switch (column.DataType)
                {
                    case TSQLDataType.@char:
                        Constraints = new CharConstraints(column.CharMaxLength ?? 1);
                        break;
                    case TSQLDataType.text:
                        Constraints = new TextConstraints(column.CharMaxLength ?? 1);
                        break;
                    case TSQLDataType.ntext:
                        Constraints = new NtextConstraints(column.CharMaxLength ?? 1);
                        break;
                    case TSQLDataType.varchar:
                        Constraints = new VarcharConstraints(column.CharMaxLength ?? 1);
                        break;
                    default:
                        Constraints = new StringConstraints(column.CharMaxLength ?? 1);
                        break;
                }
        }

        public override object Generate()
        {
            var lenght = Random.Next(Constraints.MinLength, Constraints.MaxLength + 1);

            var chars = new char[lenght];

            for (var i = 0; i < lenght; i++)
            {
                chars[i] = printableChars[Random.Next(printableChars.Length)];
            }

            return new string(chars).Trim();
        }
    }


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