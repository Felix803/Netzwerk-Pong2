using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ping_Pong_Client
{
    public class Ball
    {
        public int ballx = 5;//horizontale Geschwindigkeit (Vektor)
        public int bally = 5;//vertikale Geschwindigkeit (Vektor)
        public int ball_posx;
        public int ball_posy;
        public Ball(int bx, int by, int bposx, int bposy)
        {
            ballx = bx;
            bally = by;
            ball_posx = bposx;
            ball_posy = bposy;

        }
    }
}

