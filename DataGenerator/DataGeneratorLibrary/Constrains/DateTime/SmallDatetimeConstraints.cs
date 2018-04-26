namespace DataGeneratorLibrary.Constrains.DateTime
{
    public class SmallDatetimeConstraints : Datetime2Constraints
    {
        public SmallDatetimeConstraints()
        {
            MinDatetime = new System.DateTime(1900, 1, 1, 0, 0, 0);
            MaxDatetime = new System.DateTime(2079, 6, 6, 23, 59, 59);
        }
    }
}