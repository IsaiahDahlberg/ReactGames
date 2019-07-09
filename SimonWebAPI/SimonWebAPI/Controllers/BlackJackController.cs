using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimonWebAPI.Factory;
using SimonWebAPI.GameLogic.BlackJackStuffs;
using SimonWebAPI.Interfaces;

namespace SimonWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class BlackJackController : Controller
    {
        IBlackJackDealer dealer = BLLFactory.GetBlackJackDealer();
        [HttpGet("[action]")]
        public List<string> GetPlayerHand()
        {
            return ConvertCardHand(dealer.GetPlayerHand().Hand);
        }
        [HttpGet("[action]")]
        public List<string> GetDealerHand()
        {
            return ConvertCardHand(dealer.GetDealerHand().Hand);
        }

        [HttpGet("[action]/{hit}")]
        public string PlayRound(int hit)
        {
            int status;
            if(hit == 1)
            {
                status = dealer.PlayRound(true);
            }
            else
            {
                status = dealer.PlayRound(false);
            }

            if(status == 0)
            {
                return "Hit Or Stay.";
            }
           
            if(status == 1)
            {
                return "You Won!";
            }

            if(status == 2)
            {
                return "The Dealer Won.";
            }

            return "Something broke. No status code was given.";

        }

        private List<string> ConvertCardHand(List<Card> input)
        {
            List<string> output = new List<string>();

            foreach(var c in input)
            {
                output.Add(string.Concat(c.Suit.ToString(),c.Value.ToString()));
            }

            return output;
        }
    }
}