using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication14
{
    class Deserializer
    {
        public void deserialize(string received)
        {
            string[] array_received_server_data = received.Split(',');
            for (int i = 0; i < array_received_server_data.Length; i++)
            {
                Console.WriteLine(array_received_server_data[i]);
            }
        }
    }
}
