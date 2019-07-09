using SimonWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimonWebAPI.Interfaces
{
    public interface ISnakeTracker
    {
        List<CoordBundle> GetCoordBundle();
        void CreateNewGame();
        bool MoveSnake(int direction);
    }
}
