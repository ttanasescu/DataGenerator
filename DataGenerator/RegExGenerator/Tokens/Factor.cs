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

        public override string Generate(int maxLength = 10)
        {
            var count = Random.Next(_quantifier.Minimum, Math.Min(_quantifier.Maximum, maxLength) + 1);
            var output = "";
            for (var i = 0; i < count; i++)
            {
                output += _internal.Generate();
            }

            return output;
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