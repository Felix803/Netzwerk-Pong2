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
        public string serialize_player1(Player player1)
        {
            serialized = player1.go_down + "," + player1.go_up + "," + player1.player_score + ",";
            return serialized;
        }

        public string serialize_player2(Player player2)
        {
            serialized = player2.go_down + "," + player2.go_up + "," + player2.player_score;
            return serialized;
        }
        public string serialize_ball_data(Ball ball1)
        {
            ball_data_serialized = ball1.ballx + "," + ball1.bally + "," + ball1.ball_posx + "," + ball1.ball_posy;
            return ball_data_serialized;
        }
    }
}

