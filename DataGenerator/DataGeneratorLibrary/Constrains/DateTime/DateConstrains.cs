namespace DataGeneratorLibrary.Constrains.DateTime
{
    public class DateConstrains : Constrains
    {
        public System.DateTime MinDate { get; set; } = new System.DateTime(0001, 1, 1);
        public System.DateTime MaxDate { get; set; } = new System.DateTime(9999, 12, 31);
    }
}