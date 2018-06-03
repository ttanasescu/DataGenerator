﻿using System;

namespace RegExGenerator.Tokens
{
    public class Choice : RegEx
    {
        private RegEx _firstChoice;
        private RegEx _secondChoice;

        public Choice(RegEx firstChoice, RegEx secondChoice)
        {
            _firstChoice = firstChoice;
            _secondChoice = secondChoice;
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
            Console.WriteLine("C");
            _firstChoice.Print(indent);
            _secondChoice.Print(indent, true);
        }
    }
}