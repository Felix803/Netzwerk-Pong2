using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ping_Pong_Client
{
    class Serializer
    {
        string serialized;
        string ball_data_serialized;
        public string serialize_player(Player player)
        {
            serialized = player.go_down + "," + player.go_up + "," + player.player_score + "," + player.player_posy;
            return serialized;
        }

        public string serialize_ball_data(Ball ball1)
        {
            ball_data_serialized = ","+ball1.ballx + "," + ball1.bally + "," + ball1.ball_posx + "," + ball1.ball_posy;
            return ball_data_serialized;
        }
    }
}

