﻿using System;

namespace RegExGenerator.Tokens
{
    public class Digit : RegEx
    {
        public override string Generate(int maxLength = 10)
        {
            var chars = Characters.Digits;
            return chars[Random.Next(chars.Length)].ToString();
        }

        public override void Print(string indent, bool last)
        {
            Console.Write(indent);
            Console.Write(last ? "└─" : "├─");

            Console.WriteLine("\\d");
        }
    }
}