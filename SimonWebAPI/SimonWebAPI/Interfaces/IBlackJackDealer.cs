using SimonWebAPI.GameLogic.BlackJackStuffs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimonWebAPI.Interfaces
{
    public interface IBlackJackDealer
    {
        CardHand GetPlayerHand();
        CardHand GetDealerHand();
        int PlayRound(bool playerHit);
    }
}
