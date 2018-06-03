using DataGeneratorLibrary.DataSources;

namespace DataGeneratorLibrary.Constrains.Strings
{
    public class VarcharConstraints : StringConstraints
    {
        public bool UseRegEx { get; set; }
        public bool UseTemplateData { get; set; }
        public TemplateDataEnum TemplateData { get; set; }
        public string RegEx { get; set; }

        public VarcharConstraints(int? maxLength) : base(maxLength)
        {
            //MaxPossibleLength = 8000;
        }
    }
}