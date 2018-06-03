using System;

namespace RegExGenerator.Tokens
{
    public class Range : RegEx
    {
        private readonly RegEx _first;
        private readonly RegEx _last;

        public Range(RegEx first, RegEx last)
        {
            _first = first;
            _last = last;
        }

        public override string Generate(int maxLength)
        {
            if (!(_first is Terminal first) || !(_last is Terminal last))
            {
                throw new Exception("Only terminal chars allowed.");
            }

            return ((char) Random.Next(first.Char, last.Char + 1)).ToString();
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
            Console.WriteLine("R");
            _first.Print(indent);
            _last.Print(indent, true);
        }
    }
}