using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimonWebAPI.Models
{
    public class CardSuits
    {
        public enum Suits { Hearts, Clubs, Spades, Diamonds, Hidden };
        public enum Value { Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Hidden };
    }
}
