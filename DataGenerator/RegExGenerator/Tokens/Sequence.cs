using System;

namespace RegExGenerator.Tokens
{
    public class Sequence : RegEx
    {
        private RegEx _first;
        private RegEx _second;

        public Sequence(RegEx first, RegEx second)
        {
            _first = first;
            _second = second;
        }

        public override string Generate(int maxLength)
        {
            return _first.Generate(maxLength) + _second.Generate(maxLength);
        }

        public override void Print(string indent, bool last)
        {
            Console.Write(indent);
            if (last)
            {
                Console.Write("└─");
                indent += "  ";
            }
            else
            {
                Console.Write("├─");
                indent += "│ ";
            }
            Console.WriteLine("S");
            _first.Print(indent);
            _second.Print(indent, true);
        }
    }
}