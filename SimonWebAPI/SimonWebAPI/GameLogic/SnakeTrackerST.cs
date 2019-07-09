using SimonWebAPI.GameLogic.SnakeBits;
using SimonWebAPI.Interfaces;
using SimonWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimonWebAPI.GameLogic
{
    public class SnakeTrackerST : ISnakeTracker
    {
        private static SnakeHead snake;
        private static Apple apple;

        public void CreateNewGame()
        {
            snake = new SnakeHead();
            apple = new Apple()
            {
                xCoord = 2,
                yCoord = 5,
            };
        }

        public List<CoordBundle> GetCoordBundle()
        {
            var bundle = snake.PassAllCoord();
            bundle.Add(new CoordBundle() { XCoord = apple.xCoord, YCoord = apple.yCoord, SnakeId = 700 });
            return bundle;
        }

        public bool MoveSnake(int direction)
        {
            int currentX = snake.xCoord;
            int currentY = snake.yCoord;
            switch (direction)
            {
                case 1:
                    currentY += 1;
                    break;
                case 2:
                    currentX -= 1;
                    break;
                case 3:
                    currentY -= 1;
                    break;
                case 4:
                    currentX += 1;
                    break;
                default:
                    throw new Exception();
            }
            bool nothit = snake.Move(currentX, currentY, CheckForApple(currentX, currentY));
            if (!nothit)
                CreateNewGame();
            return nothit;
  
        }

        private bool CheckForApple(int currentX, int currentY)
        {
            if(currentX == apple.xCoord && currentY == apple.yCoord)
            {
                CreateNewApple();
                return true;
            }
            return false;

        }

        private void CreateNewApple()
        {
            Random ran = new Random();
            var bundle = GetCoordBundle();

            int x = 1;
            int y = 1;
            var appleIsUnderSnake = true;

            while (appleIsUnderSnake)
            {
                x = ran.Next(1, 11);
                y = ran.Next(1, 11);
                appleIsUnderSnake = false;
                foreach (var s in bundle)
                {
                    if (s.XCoord == x && s.YCoord == y)
                    {
                        appleIsUnderSnake = true;
                    }
                }
            }

            apple.yCoord = x;
            apple.xCoord = y;
        }
    }
}
