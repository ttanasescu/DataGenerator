namespace DataGeneratorLibrary.Constrains.DateTime
{
    public class Datetime2Constrains : Constrains
    {
        public System.DateTime MinDatetime { get; set; } = System.DateTime.MinValue;
        public System.DateTime MaxDatetime { get; set; } = System.DateTime.MaxValue;
    }
}