using System;
using System.Diagnostics;

namespace RegExGenerator.Tokens
{
    public abstract class RegEx
    {
        public static readonly Epsilon Epsilon = new Epsilon();

        public static Random Random { get; } = new Random();

        public abstract string Generate();

        [Conditional("DEBUG")]
        public abstract void Print(string indent = "", bool last = false);
    }
}
