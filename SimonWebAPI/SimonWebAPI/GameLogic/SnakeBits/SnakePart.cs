using SimonWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimonWebAPI.GameLogic.SnakeBits
{
    public class SnakePart
    {
        public int id;
        public bool hasChild;
        SnakePart child;

        public int xCoord { get; set; }
        public int yCoord { get; set; }

        public SnakePart(int cId, int xC, int yC)
        {
            id = cId;
            xCoord = xC;
            yCoord = yC;
            hasChild = false;
        }

        public void MoveChildSnake(int oldX, int oldY, bool birthSnakePart)
        {
            int passCoordX = xCoord;
            int passCoordY = yCoord;

            xCoord = oldX;
            yCoord = oldY;

            if (hasChild)
            {
                child.MoveChildSnake(passCoordX, passCoordY, birthSnakePart);
            }
            else if (birthSnakePart)
            {
                hasChild = true;
                MakeChild(passCoordX, passCoordY);
            }
        }

        public List<CoordBundle> GetCoordBundle(List<CoordBundle> bundle)
        {
            CoordBundle coords = new CoordBundle()
            {
                SnakeId = id,
                XCoord = xCoord,
                YCoord = yCoord
            };

            bundle.Add(coords);

            if (hasChild)
            {
               bundle = child.GetCoordBundle(bundle);
            }

            return bundle;
        }

        private void MakeChild(int xC, int yC)
        {
            child = new SnakePart(id+1, xC, yC);
        }
    }
}
