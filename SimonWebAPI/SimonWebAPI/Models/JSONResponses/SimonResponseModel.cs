using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimonWebAPI.Models.JSONResponses
{
    public class SimonResponseModel
    {
        public IEnumerable<MoveColor.Color> Moves { get; set; }
        public bool MoveC { get; set; }
    }
}
