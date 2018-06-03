using System;

namespace RegExGenerator.Tokens
{
    public class Primitive : RegEx
    {
        public char Char { get; }

        public Primitive(char c)
        {
            Char = c;
        }

        public override void Print(string indent, bool last)
        {
            Console.Write(indent);
            Console.Write(last ? "└─" : "├─");

            Console.WriteLine(Char);
        }
    }
}