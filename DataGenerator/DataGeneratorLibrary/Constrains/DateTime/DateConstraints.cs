namespace DataGeneratorLibrary.Constrains.DateTime
{
    public class DateConstraints : Constraints
    {
        public System.DateTime MinDate { get; set; } = System.DateTime.Today;
        public System.DateTime MaxDate { get; set; } = System.DateTime.Today;
        public System.DateTime MinPossibleDate { get; set; } = new System.DateTime(0001, 1, 1);
        public System.DateTime MaxPossibleDate { get; set; } = new System.DateTime(9998, 12, 31);
    }
}