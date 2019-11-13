using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Xml;
using System.Xml.Serialization;

namespace Ping_Pong_Client
{
    class Player
    {
        public bool go_up;//verwendet für validiere Key Events
        public bool go_down;//verwendet für validiere Key Events
        public int player_score = 0;//Punktzahl Spieler 1

        public Player(bool goup, bool godown, int playerscore)
        {
            go_up = goup;
            go_down = godown;
            player_score = playerscore;
        }

        
    }
}
