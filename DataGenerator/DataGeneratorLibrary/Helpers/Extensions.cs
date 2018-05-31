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

        public static string ByteArrayToHex(this byte[] bytes)
        {
            var lookup = new uint[256];
            for (var i = 0; i < 256; i++)
            {
                var s = i.ToString("X2");
                lookup[i] = s[0] + ((uint) s[1] << 16);
            }

            var result = new char[bytes.Length * 2];
            for (var i = 0; i < bytes.Length; i++)
            {
                var val = lookup[bytes[i]];
                result[2 * i] = (char) val;
                result[2 * i + 1] = (char) (val >> 16);
            }

            return new string(result);
        }
    }
}