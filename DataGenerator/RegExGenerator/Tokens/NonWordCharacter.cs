using System;

namespace RegExGenerator.Tokens
{
    public class NonWordCharacter : RegEx
    {
        public override string Generate(int maxLength = 10)
        {
            var chars = Characters.NonWordChars;
            return chars[Random.Next(chars.Length)].ToString();
        }

        public override void Print(string indent, bool last)
        {
            Console.Write(indent);
            Console.Write(last ? "└─" : "├─");

            Console.WriteLine("\\W");
        }
    }
}