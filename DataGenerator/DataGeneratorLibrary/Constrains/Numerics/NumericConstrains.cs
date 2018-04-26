namespace DataGeneratorLibrary.Constrains.Numerics
{
    public class NumericConstrains<T> : Constrains
    {
        public T MinPossibleValue { get; protected set; }
        public T MaxPossibleValue { get; protected set; }
    }
}