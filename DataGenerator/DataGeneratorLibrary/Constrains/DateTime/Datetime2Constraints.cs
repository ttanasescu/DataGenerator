namespace DataGeneratorLibrary.Constrains.DateTime
{
    public class Datetime2Constraints : Constraints
    {
        public System.DateTime MinDatetime { get; set; } = System.DateTime.UtcNow;
        public System.DateTime MaxDatetime { get; set; } = System.DateTime.UtcNow;

        public System.DateTime MinPossibleDatetime { get; set; } = System.DateTime.MinValue;
        public System.DateTime MaxPossibleDatetime { get; set; } = System.DateTime.MaxValue;
    }
}