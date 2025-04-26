using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card_game
{
    public class Player
    {
        public string Name { get; }
        public Queue<Karta> Cards { get; }

        public Player(string name)
        {
            Name = name;
            Cards = new Queue<Karta>();
        }

        public void AddCards(IEnumerable<Karta> cards)
        {
            foreach (var card in cards)
                Cards.Enqueue(card);
        }

        public void AddCard(Karta card)
        {
            Cards.Enqueue(card);
        }

        public Karta PlayCard()
        {
            return Cards.Count > 0 ? Cards.Dequeue() : null;
        }

        public void ShowCards()
        {
            Console.WriteLine($"{Name} has {Cards.Count} cards.");
        }

        public bool HasCards()
        {
            return Cards.Count > 0;
        }


    }
}
