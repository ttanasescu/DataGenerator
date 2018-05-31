using DataGeneratorLibrary.DAL;

namespace DataGeneratorLibrary.DataExport
{
    internal interface IFormatter
    {
        string GetString(object @object, Column column);
    }
}