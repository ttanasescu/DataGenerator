namespace DataGeneratorLibrary.Constrains.Numerics
{
    public class NumericConstraints<T> : Constraints
    {
        public T MinPossibleValue { get; protected set; }
        public T MaxPossibleValue { get; protected set; }
    }
}