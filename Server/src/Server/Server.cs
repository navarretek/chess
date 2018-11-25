using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
        
    class Server
    {
        #region Fields
        private IPAddress _ipAddress;
        private int _port;
        private TcpListener tcpListener;
        private Thread _listenThread;

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
                Console.WriteLine($"Starting Server on IP: {_ipAddress.ToString()} : {_port}");
                tcpListener.Start();
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public void StopServer()
        {
            try
            {
                Console.WriteLine($"Stoping Server on IP: {_ipAddress.MapToIPv4()} : {_port}");
                // If listener is not null then stop
                tcpListener?.Stop();
            }
            catch 
            {
            }
        }

        // TODO: Start listening to incoming connections
        /// <summary>
        /// Start listening for connections.
        /// </summary>
        public void Listen(bool forceRestart = false)
        {
            if (_listenThread == null)
            {
                _listenThread = new Thread(ListeningThreadFunction);
                _listenThread.Start();
            }
            else if (forceRestart)
            {
                Console.WriteLine("Restarting Listener");
                _listenThread.Abort();
                Thread.Sleep(5000);            
                Listen();
            }
        }

        public void StopListening()
        {
            if (_listenThread != null &&_listenThread.IsAlive)
            {
                _listenThread.Abort();
            }
        }


        private void ListeningThreadFunction()
        {
            try
            {
                Console.Write("Listening...");
                while (true)
                {
                    TcpClient client = tcpListener.AcceptTcpClient();
                    NetworkStream stream = client.GetStream();
                    byte[] r = new byte[100];

                    stream.Read(r, 0, r.Length);

                    Console.Write(Encoding.ASCII.GetString(r , 0, r.Length));

                }
            }
            catch 
            {
                //ignore
            }
        }
    }
}
