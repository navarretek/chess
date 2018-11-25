using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server.src.Server
{
        
    class Server
    {
        #region Fields
        private IPAddress _ipAddress;
        private int _port;
        private TcpListener tcpListener;
        #endregion

        public String Port
        {
            get => _ipAddress.ToString();
        }        
        public String IpAddress
        {
            get => _ipAddress.ToString();
        }        

        public Server(IPAddress ipAddress, int port)
        {
            this._ipAddress = ipAddress;
            _port = port;
        }

        public bool StartServer()
        {
            try
            {
                tcpListener = new TcpListener(_ipAddress, _port);
                tcpListener.Start();
                return true;
            }
            catch 
            {
                return false;
            }
        }

        // TODO: Start listening to incoming connections
        /// <summary>
        /// Start listening for connections.
        /// </summary>
        public void Listen()
        {

        }
    }
}
