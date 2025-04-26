using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card_game
{
    public class Karta
    {
        public string Suit { get; }
        public string Rank { get; }
        public int Value { get; }

        public Karta(string suit, string rank, int value)
        {
            Suit = suit;
            Rank = rank;
            Value = value;
        }

        public override string ToString()
        {
            return $"{Rank} {Suit}";
        }
    }
}

