using System.Diagnostics;

namespace RegExGenerator.Tokens
{
    public abstract class RegEx
    {
        public static readonly Epsilon Epsilon = new Epsilon();

        [Conditional("DEBUG")]
        public abstract void Print(string indent = "", bool last = false);
    }
}
