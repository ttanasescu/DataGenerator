using DataGeneratorLibrary.Generators;

namespace DataGeneratorLibrary.DAL
{
    public class Column
    {
        public Constrains.Constraints Constraints { get; set; }
        public string Schema { get; set; }
        public int OdinalPosition { get; set; }
        public string Name { get; set; }
        public TSQLDataType DataType { get; set; }
        public int? CharMaxLength { get; set; }
        public byte? NumericPrecision { get; set; }
        public short? NumericPrecisionRadix { get; set; }
        public int? NumericScale { get; set; }
    }
}