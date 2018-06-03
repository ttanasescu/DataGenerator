using System;

namespace RegExGenerator.Tokens
{
    public class Factor : RegEx
    {
        private readonly RegEx _internal;
        private readonly Quantifier _quantifier;

        public Factor(RegEx @internal, Quantifier quantifier)
        {
            _internal = @internal;
            _quantifier = quantifier;
        }

        public override void Print(string indent, bool last)
        {
            Console.WriteLine(
                $"{indent}{{{_quantifier.Minimum}," +
                $"{(_quantifier.Maximum == int.MaxValue ? "max" : _quantifier.Maximum.ToString())}}}");
            _internal.Print(indent, last);
        }
    }
}