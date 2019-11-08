using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication14
{
    class Serializer
    {
        Player player1 = new Player(2, true, false);
        string tosend;
        public string serialize()
        {
            tosend = player1.playerscore + "," + player1.keydown + "," + player1.keyup;
            return tosend;
        }
    }
}
