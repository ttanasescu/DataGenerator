using System;

namespace RegExGenerator.Tokens
{
    public class WordCharacter : RegEx
    {
        public override void Print(string indent, bool last)
        {
            Console.Write(indent);
            Console.Write(last ? "└─" : "├─");

            Console.WriteLine("\\w");
        }
    }
}