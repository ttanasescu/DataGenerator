using DataGeneratorLibrary.DataSources;

namespace DataGeneratorLibrary.Constrains.Strings
{
    public class VarcharConstraints : StringConstraints
    {
        public bool UseTemplateData { get; set; }
        public TemplateDataEnum TemplateData { get; set; }

        public VarcharConstraints(int? maxLength) : base(maxLength)
        {
            //MaxPossibleLength = 8000;
        }
    }
}