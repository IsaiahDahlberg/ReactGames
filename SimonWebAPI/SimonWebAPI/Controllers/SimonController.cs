using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimonWebAPI.Factory;
using SimonWebAPI.Interfaces;
using SimonWebAPI.Models;

namespace SimonWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class SimonController : Controller
    {
        ISimonTracker _simon = BLLFactory.GetSimonTracker();

        [HttpGet("[action]")]
        public IEnumerable<MoveColor.Color> NewGame()
        {
            _simon.ResetMoves();
            _simon.AddNewMoveColor();
            return _simon.GetCurrentMoveSet();
        }

        [HttpGet("[action]")]
        public IEnumerable<MoveColor.Color> Get()
        {
            return _simon.GetCurrentMoveSet();
        }

        [HttpGet("[action]/{index}/{color}")]
        public IActionResult Check(int index, int color)
        {
            if (_simon.CheckMove(index,(MoveColor.Color)color))
            {
                if(_simon.GetCurrentMoveSet().Count() - 1 == index)
                {
                    //I may add the nextMove here
                }
                return Ok(1);
            }
            _simon.ResetMoves();
            return Ok(0);
        }

        [HttpGet("[action]")]
        public IActionResult Reset()
        {
            _simon.ResetMoves();
            return Ok();
        }

        [HttpGet("[action]")]
        public IActionResult Next()
        {
            _simon.AddNewMoveColor();
            return Ok();
        }
    }
}