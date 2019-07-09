using SimonWebAPI.Interfaces;
using SimonWebAPI.Models;
using System;
using System.Collections.Generic;

namespace SimonWebAPI.GameLogic
{
    public class SimonTrackerST : ISimonTracker
    {

        private static List<MoveColor.Color> _moves = new List<MoveColor.Color>();
        private static Random _random = new Random();
        public void AddNewMoveColor()
        {
            _moves.Add((MoveColor.Color)_random.Next(1, 5));
        }

        public bool CheckMove(int index, MoveColor.Color color )
        {
            if(_moves[index] == color)
            {
                return true;
            }
            return false;
        }

        public IEnumerable<MoveColor.Color> GetCurrentMoveSet()
        {
            return _moves;
        }

        public void ResetMoves()
        {
            _moves = new List<MoveColor.Color>();
        }
    }
}