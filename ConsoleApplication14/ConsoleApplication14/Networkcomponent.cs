using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication14
{
    abstract class Networkcomponent
    {
        protected static string ip;
        protected static int port = 12345;
        protected static string handshake;
        public virtual void send()
        {

        }

        public virtual void start()
        {

        }

        public virtual void receive()
        {

        }
    }
}
