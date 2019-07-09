using SimonWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimonWebAPI.GameLogic.SnakeBits
{
    public class SnakeHead
    {
        SnakePart child;

        public int xCoord { get; set; }
        public int yCoord { get; set; }

        public SnakeHead()
        {
            xCoord = 5;
            yCoord = 5;

            child = new SnakePart(1, 5, 4);
        }

        public List<CoordBundle> PassAllCoord()
        {
            List<CoordBundle> bundle = new List<CoordBundle>()
            {
                new CoordBundle()
                {
                    SnakeId = 0,
                    XCoord = this.xCoord,
                    YCoord = this.yCoord
                }
            };
            return child.GetCoordBundle(bundle);
        }


        public bool Move(int x, int y, bool birthSnakePart)
        {
            bool hit = !HitSomething(x, y) ? true : false;
            child.MoveChildSnake(xCoord, yCoord, birthSnakePart);

            xCoord = x;
            yCoord = y;
            return hit;
        }

        private bool HitSomething(int x, int y)
        {
            List<CoordBundle> bundle = new List<CoordBundle>();
            bundle = child.GetCoordBundle(bundle);
            foreach(var b in bundle)
            {
                if(b.YCoord == y && b.XCoord == x)
                {
                    return true;
                }
            }
            if(y > 10 || y < 1|| x > 10 || x < 1)
            {
                return true;
            }
            return false;
        }
    }
}
