using SimonWebAPI.GameLogic.BlackJackStuffs;
using SimonWebAPI.Interfaces;
using SimonWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimonWebAPI.GameLogic
{
    public class BlackJackDealer : IBlackJackDealer
    {
        private static Deck _deck = new Deck();
        private static CardHand _dealer = new CardHand();
        private static CardHand _player = new CardHand();
        private static bool InGame { get; set; }
        private static bool FirstDeal { get; set; }
        private static bool PlayerWon { get;  set; }

        public CardHand GetPlayerHand()
        {
            return _player;
        }

        public CardHand GetDealerHand()
        {
            if (InGame)
            {
                CardHand HiddenDealerHand = new CardHand();
                for (int i = 0; i < _dealer.Hand.Count; i++)
                {                    
                    if(i == 0)
                    {
                        HiddenDealerHand.Hand.Add(new Card() { Value = (CardSuits.Value)13, Suit = (CardSuits.Suits)4 });
                    }
                    else
                    {
                        HiddenDealerHand.Hand.Add(_dealer.Hand[i]);
                    }
                }                  
                return HiddenDealerHand;
            }
            else
            {
                return _dealer;
            }
        }
   
        public int PlayRound(bool playerHit)
        {
            // 0 = Game in progress. 1 = player won. 2 = dealer won.
            if (InGame)
            {
                FirstDeal = false;
                if (playerHit)
                {
                    DrawCard(true);
                }
                while (DealerShouldDraw())
                {
                    DrawCard(false);
                }

                if (HandBusted(false))
                {
                    InGame = false;
                    PlayerWon = true;
                }
                if (HandBusted(true))
                {
                    InGame = false;
                    PlayerWon = false;
                }

                if (!InGame)
                    return PlayerWon ? 1 : 2;

                return 0;
            }
            else
            {
               return DealHands();
            }                  

            
        }

        private int DealHands()
        {
            InGame = true;
            FirstDeal = true;
            _deck.Shuffle();
            _dealer = new CardHand();
            _player = new CardHand();
            for (int i = 1; i < 5; i++)
            {
                if (i % 2 != 0)
                {
                    DrawCard(true);
                }
                else
                {
                    DrawCard(false);
                }
            }
            if (CalculateHand(_dealer.Hand) == 21)
            {
                PlayerWon = false;
                return 2;
            }
            if (CalculateHand(_player.Hand) == 21)
            {
                PlayerWon = true;
                return 1;
            }
            return 0;
        }

        private void DrawCard(bool forPlayer)
        {
            if (forPlayer)
            {
                _player.Hand.Add(_deck.DrawCard());
            }
            else
            {
                _dealer.Hand.Add(_deck.DrawCard());
            }       
        }

        private bool DealerShouldDraw()
        {
            return CalculateHand(_dealer.Hand) <= 16 ? true : false;
        }

        private int CalculateHand(List<Card> hand)
        {
            int sum = 0;
            foreach(var c in hand)
            {
                switch (c.Value)
                {
                    case (CardSuits.Value)0:
                        sum += 11;
                        break;
                    case (CardSuits.Value)1:
                        sum += 2;
                        break;
                    case (CardSuits.Value)2:
                        sum += 3;
                        break;
                    case (CardSuits.Value)3:
                        sum += 4;
                        break;
                    case (CardSuits.Value)4:
                        sum += 5;
                        break;
                    case (CardSuits.Value)5:
                        sum += 6;
                        break;
                    case (CardSuits.Value)6:
                        sum += 7;
                        break;
                    case (CardSuits.Value)7:
                        sum += 8;
                        break;
                    case (CardSuits.Value)8:
                        sum += 9;
                        break;
                    default:
                        sum += 10;
                        break;
                }
            }
            if(sum > 21)
            {
                foreach(var c in hand)
                {
                    if(c.Value == 0)
                    {
                        sum -= 10;
                        break;
                    }
                }
            }
            return sum;
        }

        private bool HandBusted(bool forPlayer)
        {
            int sum = forPlayer ? CalculateHand(_player.Hand) : CalculateHand(_dealer.Hand);
            return sum > 21 ? true : false;
        }
    }
}
