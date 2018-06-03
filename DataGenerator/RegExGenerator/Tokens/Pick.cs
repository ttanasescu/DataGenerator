using System;
using System.Collections.Generic;

namespace RegExGenerator.Tokens
{
    public class Pick : RegEx
    {
        public List<RegEx> Picks { get; }
        private readonly bool _exclude;

        public Pick(bool exclude)
        {
            _exclude = exclude;
            Picks = new List<RegEx>();
        }

        public override string Generate(int maxLength = 10)
        {
            return Picks[Random.Next(Picks.Count)].Generate();
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

            Console.WriteLine("P");
            if (_exclude)
            {
                Console.WriteLine($"{indent}'^'");
            }
            for (var i = 0; i < Picks.Count; i++)
            {
                var pick = Picks[i];


                pick.Print(indent, i + 1 == Picks.Count);
            }
        }
    }
}