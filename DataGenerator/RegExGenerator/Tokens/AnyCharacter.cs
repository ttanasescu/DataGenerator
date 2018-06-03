using System;

namespace RegExGenerator.Tokens
{
    public class AnyCharacter : RegEx
    {
        public override void Print(string indent, bool last)
        {
            Console.Write(indent);
            Console.Write(last ? "└─" : "├─");

            Console.WriteLine(".");
        }
    }
}