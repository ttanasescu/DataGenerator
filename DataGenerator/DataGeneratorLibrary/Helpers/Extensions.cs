using System;

namespace DataGeneratorLibrary.Helpers
{
    public static class Extensions
    {
        public static T Constrain<T>(T value, T minValue, T maxValue) where T : IComparable<T>
        {
            if (value.CompareTo(minValue) < 0)
            {
                return minValue;
            }
            if (value.CompareTo(maxValue) > 0)
            {
                return maxValue;
            }
            return value;
        }
    }
}