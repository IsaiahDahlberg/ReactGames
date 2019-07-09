using SimonWebAPI.Interfaces;
using SimonWebAPI.GameLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimonWebAPI.Factory
{
    public static class BLLFactory
    {
        public static ISimonTracker GetSimonTracker()
        {
            return  new SimonTrackerST();
        }

        public static ISnakeTracker GetSnakeTracker()
        {
            return new SnakeTrackerST();
        }

        public static IBlackJackDealer GetBlackJackDealer()
        {
            return new BlackJackDealer();
        }
    }
}
