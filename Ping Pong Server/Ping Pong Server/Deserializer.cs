using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ping_Pong_Client
{
    class Deserializer
    {
        public string[] deserialize(string received)
        {
            string[] array_received_server_data = received.Split(',');
            return array_received_server_data;
        }
    }
}
