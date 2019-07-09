using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimonWebAPI.Factory;
using SimonWebAPI.Interfaces;
using SimonWebAPI.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SimonWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class SnakeController : Controller
    {
        ISnakeTracker _snake = BLLFactory.GetSnakeTracker();

        [HttpGet("[action]")]
        public List<byte> GetCoords()
        {
            return CreateGrid(_snake.GetCoordBundle());
        }

        [HttpGet("[action]")]
        public IActionResult NewGame()
        {
            _snake.CreateNewGame();
            return Ok();
        }

        [HttpGet("[action]/{direction}")]
        public List<byte> Move(int direction)
        {
            bool notHit = _snake.MoveSnake(direction);
            if (notHit)
            {
                return CreateGrid(_snake.GetCoordBundle());
            }
            return null;
        }

        public List<byte> CreateGrid(List<CoordBundle> input)
        {
            List<byte> grid = new List<byte>();
            for(int y = 1; y <= 10; y++)
            {
                for (int x = 1; x <= 10; x++)
                {
                    bool found = false;
                    foreach (var c in input)
                    {
                        if (c.XCoord == x && c.YCoord == y)
                        {
                            found = true;
                            if (c.SnakeId == 700)
                            {
                                grid.Add(2);
                                break;
                            }else if(c.SnakeId == 0)
                            {
                                grid.Add(8);
                                break;
                            }
                            grid.Add(1);
                            break;
                        }
                    }
                    if(!found)
                        grid.Add(0);
                }
            }
            return grid;
        }
    }
}
