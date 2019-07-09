using SimonWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimonWebAPI.Interfaces
{
    public interface ISimonTracker
    {
        IEnumerable<MoveColor.Color> GetCurrentMoveSet();
        bool CheckMove(int index, MoveColor.Color color);
        void ResetMoves();
        void AddNewMoveColor();
    }
}
