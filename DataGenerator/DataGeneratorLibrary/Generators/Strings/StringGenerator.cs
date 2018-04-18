using DataGeneratorLibrary.Constrains.Numerics;
using DataGeneratorLibrary.Constrains.Strings;

namespace DataGeneratorLibrary.Generators.Strings
{
    public class StringGenerator : DataTypeGenerator
    {
        string printableChars =
            " !\"#$%&\'()*+,-./30123456789:;<=>?4@ABCDEFGHIJKLMNO5PQRSTUVWXYZ" +
            "[\\]^_6`abcdefghijklmno7pqrstuvwxyz{|}~";

        private StringConstrains Constrains { get; set; }

        public StringGenerator(Column column) : base(column)
        {
            if (Column.constrains is StringConstrains constrains)
            {
                Constrains = constrains;
            }
            else
                switch (column.DataType)
                {
                    case TSQLDataType.@char:
                        Constrains = new CharConstrains(column.CharMaxLength ?? 1);
                        break;
                    case TSQLDataType.text:
                        Constrains = new TextConstrains(column.CharMaxLength ?? 1);
                        break;
                    case TSQLDataType.ntext:
                        Constrains = new NtextConstrains(column.CharMaxLength ?? 1);
                        break;
                    case TSQLDataType.varchar:
                        Constrains = new VarcharConstrains(column.CharMaxLength ?? 1);
                        break;
                    default:
                        Constrains = new StringConstrains(column.CharMaxLength ?? 1);
                        break;
                }
        }

        public override object Generate()
        {
            var lenght = Random.Next(Constrains.MinLength, Constrains.MaxLength + 1);

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
        private StringConstrains Constrains { get; set; }

        public BinaryGenerator(Column column) : base(column)
        {
            if (Column.constrains is StringConstrains constrains)
            {
                Constrains = constrains;
            }
            else
                switch (column.DataType)
                {
                    case TSQLDataType.binary:
                        Constrains = new BinaryConstrains(column.CharMaxLength ?? 1);
                        break;
                    case TSQLDataType.image:
                        Constrains = new ImageConstrains(column.CharMaxLength ?? 1);
                        break;
                    case TSQLDataType.varbinary:
                        Constrains = new VarbinaryConstrains(column.CharMaxLength ?? 1);
                        break;
                    default:
                        Constrains = new StringConstrains(column.CharMaxLength ?? 1);
                        break;
                }
        }

        public override object Generate()
        {
            var lenght = Random.Next(Constrains.MinLength, Constrains.MaxLength + 1);

            var buffer = new byte[lenght];
            Random.NextBytes(buffer);

            return buffer;
        }
    }
}