using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Task4DzmitryKhrapunouSocketServer
{
    public class SocketServer
    {
        /// <summary>
        /// Local endpoint
        /// </summary>
        IPEndPoint ipEndPoint = null;

        /// <summary>
        /// Server socket instance
        /// </summary>
        Socket serverSocket = null;

        /// <summary>
        /// Server listener instance
        /// </summary>
        Socket serverListener = null;

        /// <summary>
        /// Port number
        /// </summary>
        public int Port { get; private set; }

        /// <summary>
        /// Server IP address.
        /// </summary>
        public string IpAdress { get; private set; }
              
        public SocketServer(int port = 1408, string ipAdress = "127.0.0.1")
        {
            Port = port;
            IpAdress = ipAdress;

            ipEndPoint = new IPEndPoint(IPAddress.Parse(ipAdress), port);
            serverListener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverListener.Bind(ipEndPoint);
        }

        /// <summary>
        /// Method waiting and get message from clients
        /// </summary>
        /// <param name="num"></param>
        public void ListenClient(int num)
        {
            if (serverListener != null)
            {
                serverListener.Listen(num);
                serverSocket = serverListener.Accept();
            }
            else
            {
                throw new Exception("The server listener was not created");
            }

            while (true)
            {
                byte[] buffer = new byte[1024];

                var size = 0;

                StringBuilder data = new StringBuilder();

                do
                {
                    size = serverListener.Receive(buffer);
                    data.Append(Encoding.UTF8.GetString(buffer, 0, size));
                }
                while (serverListener.Available > 0);

                byte[] bytes = Encoding.UTF8.GetBytes("The message is successfully received");
                serverSocket.Send(bytes);

                serverListener.Shutdown(SocketShutdown.Both);
                serverListener.Close();
            }
        }
    }
}
