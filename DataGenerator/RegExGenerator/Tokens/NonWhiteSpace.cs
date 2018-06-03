using System;

namespace RegExGenerator.Tokens
{
    public class NonWhiteSpace : RegEx
    {
        public override string Generate()
        {
            var chars = Characters.NonWhiteSpaces;
            return chars[Random.Next(chars.Length)].ToString();
        }

        public override void Print(string indent, bool last)
        {
            Console.Write(indent);
            Console.Write(last ? "└─" : "├─");

            Console.WriteLine("\\S");
        }
    }
}