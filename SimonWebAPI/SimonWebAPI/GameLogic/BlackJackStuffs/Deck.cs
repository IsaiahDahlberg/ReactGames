using SimonWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimonWebAPI.GameLogic.BlackJackStuffs
{
    public class Deck
    {
        private static List<Card> _deck;

        public void Shuffle()
        {
            List<Card> shuffle = new List<Card>();
            Random random = new Random();
            for(int i = 0; i < 52; i++)
            {
                bool wrongCard = true;
                while(wrongCard)
                {
                    wrongCard = false;
                    Card card = new Card()
                    {
                        Suit = (CardSuits.Suits)random.Next(0, 4),
                        Value = (CardSuits.Value)random.Next(0, 13)
                    };
                    foreach (var c in shuffle)
                    {
                        if (c.Value == card.Value && c.Suit == card.Suit)
                        {
                            wrongCard = true;
                            break;
                        }
                    }
                    if (wrongCard)
                    {
                        continue;
                    }
                    shuffle.Add(card);
                }           
            }
            _deck = shuffle;
        }

        public Card DrawCard()
        {
            Card card = _deck[0];
            _deck.RemoveAt(0);
            return card;
        }
    }
}
