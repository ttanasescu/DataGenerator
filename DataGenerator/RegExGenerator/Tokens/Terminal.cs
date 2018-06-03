using System;

namespace RegExGenerator.Tokens
{
    public class Terminal : RegEx
    {
        public char Char { get; }

        public Terminal(char c)
        {
            Char = c;
        }

        public override string Generate(int maxLength = 10)
        {
            return Char.ToString();
        }

        public override void Print(string indent, bool last)
        {
            Console.Write(indent);
            Console.Write(last ? "└─" : "├─");

            Console.WriteLine(Char);
        }
    }
}