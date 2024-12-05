using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Rover
{
    public class Rover
    {
        public Position Pos { get; set; }

        public Rover(int x, int y, Enums.Orientation orientation) 
        {
            Pos = new Position(x, y, orientation);
        }


    }
}
