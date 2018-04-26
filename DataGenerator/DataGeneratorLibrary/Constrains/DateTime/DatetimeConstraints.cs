namespace DataGeneratorLibrary.Constrains.DateTime
{
    public class DatetimeConstraints : Datetime2Constraints
    {
        public DatetimeConstraints()
        {
            MinDatetime = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            MaxDatetime = new System.DateTime(9999, 12, 31, 23, 59, 59, 997);
        }
    }
}