using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication14
{
    class Player
    {
        public int playerscore;
        public bool keydown;
        public bool keyup;

        public Player(int ps,bool kd, bool ku)
        {
            playerscore = ps;
            keydown = kd;
            keyup = ku;
        }
    }
}
