using System.IO;
using DataGeneratorLibrary.Constrains.Strings;
using DataGeneratorLibrary.DataSources;
using DataGeneratorLibrary.DAL;

namespace DataGeneratorLibrary.Generators.Strings
{
    public class VarCharGenerator : DataTypeGenerator
    {
        private const string Chars =
            " !\"#$%&\'()*+,-./30123456789:;<=>?4@ABCDEFGHIJKLMNO5PQRSTUVWXYZ[\\]^_6`abcdefghijklmno7pqrstuvwxyz{|}~";

        private VarcharConstraints Constraints { get; set; }
        private string[] Lines { get; set; } = null;
        private TemplateDataEnum? PreviousTemplateData { get; set; } = null;

        public VarCharGenerator(Column column) : base(column)
        {
            if (Column.Constraints is VarcharConstraints constrains)
            {
                Constraints = constrains;
            }
            else
                switch (column.DataType)
                {
                    case TSQLDataType.text:
                        Constraints = new TextConstraints(column.CharMaxLength ?? 1);
                        break;
                    case TSQLDataType.ntext:
                        Constraints = new NtextConstraints(column.CharMaxLength ?? 1);
                        break;
                    default:
                        Constraints = new VarcharConstraints(column.CharMaxLength ?? 1);
                        break;
                }
        }

        public override object Generate()
        {
            return Constraints.UseTemplateData ? GenerateFromTemplate() : GenerateRandomString();
        }

        private object GenerateFromTemplate()
        {
            if (Lines == null || PreviousTemplateData != Constraints.TemplateData)
            {
                PreviousTemplateData = Constraints.TemplateData;
                var templateFileName = $"{nameof(DataSources)}\\{PreviousTemplateData}.txt";
                Lines = File.ReadAllLines(templateFileName);
            }

            var lineNumber = Random.Next(0, Lines.Length - 1);
            var str = Lines[lineNumber];

            if (str.Length>Constraints.MaxLength)
            {
                return str.Substring(0, Constraints.MaxLength);
            }

            return str;
        }

        private object GenerateRandomString()
        {
            var lenght = Random.Next(Constraints.MinLength - 1, Constraints.MaxLength) + 1;

            var chars = new char[lenght];

            for (var i = 0; i < lenght; i++)
            {
                chars[i] = Chars[Random.Next(Chars.Length)];
            }

            return new string(chars).Trim();
        }
    }
}