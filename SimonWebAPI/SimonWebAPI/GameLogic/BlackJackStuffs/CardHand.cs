using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimonWebAPI.GameLogic.BlackJackStuffs
{
    public class CardHand
    {
        public CardHand()
        {
            Hand = new List<Card>();
        }
        public List<Card> Hand { get; set; }
    }
}
