using SimonWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimonWebAPI.GameLogic.BlackJackStuffs
{
    public class Card
    {
        
        public CardSuits.Suits Suit { get; set; }
        public CardSuits.Value Value { get; set; }
    }
}
