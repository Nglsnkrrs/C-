using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card_game
{
    public class Game
    {
        private List<Player> players = new List<Player>();
        private List<Karta> deck = new List<Karta>();
        private static readonly string[] Suits = { "♠", "♥", "♦", "♣" };
        private static readonly (string rank, int value)[] Ranks = {
            ("6", 6), ("7", 7), ("8", 8), ("9", 9), ("10", 10),
            ("Jack", 11), ("queen", 12), ("King", 13), ("Ace", 14)
        };

        public Game(string player1Name, string player2Name)
        {
            players.Add(new Player(player1Name));
            players.Add(new Player(player2Name));
            CreateDeck();
            ShuffleDeck();
            DealCards();
        }

        private void CreateDeck()
        {
            foreach (var suit in Suits)
            {
                foreach (var (rank, value) in Ranks)
                {
                    deck.Add(new Karta(suit, rank, value));
                }
            }
        }

        private void ShuffleDeck()
        {
            Random rng = new Random();
            deck = deck.OrderBy(a => rng.Next()).ToList();
        }

        private void DealCards()
        {
            for (int i = 0; i < deck.Count; i++)
            {
                players[i % 2].AddCard(deck[i]);
            }
        }

        public void Start()
        {
            int round = 1;
            while (players.All(p => p.HasCards()))
            {
                Console.WriteLine($"\n--- Round {round} ---");
                PlayRound();
                round++;
            }

            var winner = players.FirstOrDefault(p => p.HasCards());
            Console.WriteLine($"\nThe Winner: {winner?.Name}!");
        }

        private void PlayRound()
        {
            var table = new List<Karta>();
            var cardsOnTable = new Dictionary<Player, Karta>();

            foreach (var player in players)
            {
                var card = player.PlayCard();
                if (card != null)
                {
                    Console.WriteLine($"{player.Name} puts: {card}");
                    table.Add(card);
                    cardsOnTable[player] = card;
                }
            }

            Player roundWinner = DetermineRoundWinner(cardsOnTable);

            if (roundWinner != null)
            {
                Console.WriteLine($"{roundWinner.Name} He takes the cards.");
                roundWinner.AddCards(table);
            }
            else
            {
                Console.WriteLine("Draw, the cards remain on the table (not taken away).");
            }

            foreach (var player in players)
            {
                player.ShowCards();
            }
        }

        private Player DetermineRoundWinner(Dictionary<Player, Karta> cardsOnTable)
        {
            var firstCard = cardsOnTable[players[0]];
            var secondCard = cardsOnTable[players[1]];

            if (firstCard.Rank == "6" && secondCard.Rank == "Ace")
            {
                return players[1];
            }
            if (secondCard.Rank == "6" && firstCard.Rank == "Ace")
            {
                return players[0];
            }

            if (firstCard.Value > secondCard.Value)
                return players[0];
            if (secondCard.Value > firstCard.Value)
                return players[1];

            return players[0];
        }
    }
}
