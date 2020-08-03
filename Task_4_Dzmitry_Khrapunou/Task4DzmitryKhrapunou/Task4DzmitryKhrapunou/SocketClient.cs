using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Task4DzmitryKhrapunouSoketClient
{
    public class SocketClient
    {
        /// <summary>
        /// Local endpoint
        /// </summary>
        IPEndPoint ipEndPoint = null;

        /// <summary>
        /// Server's IP
        /// </summary>
        IPAddress ipAddr = null;

        /// <summary>
        /// Socket instance
        /// </summary>
        Socket sender;

        /// <summary>
        /// Server IP
        /// </summary>
        public string ServerIP { get; private set; }

        /// <summary>
        /// Port number
        /// </summary>
        public int Port { get; private set; }

        /// <summary>
        /// Initializes a new instance of the ClientSocket class
        /// </summary>
        /// <param name="client"> Client instance</param>
        /// <param name="serverIP"> Server IP</param>
        /// <param name="port"> Port number</param>
        public SocketClient(int port = 1408, string serverIP = "127.0.0.1")
        {
            ServerIP = serverIP;
            Port = port;
        }

        public void Connect()
        {
            ipAddr = IPAddress.Parse(ServerIP);
            ipEndPoint = new IPEndPoint(ipAddr, Port);

            sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                sender.Connect(ipEndPoint);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }           
        }

        /// <summary>
        /// Delegate accepting any method 'void(string)
        /// </summary>
        /// <param name="msg"></param>
        public delegate void MessageFromServer(string msg);
        /// <summary>
        /// Event to get message from server
        /// </summary>
        public event MessageFromServer GetMessageFromServer;

        /// <summary>
        /// Get message from server
        /// </summary>
        /// <param name="msg"></param>
        public string GetMsg()
        {
            byte[] receivedBytes = new byte[1024];
            var size = 0;
            var serverAnswer = new StringBuilder();

            do
            {
                size = sender.Receive(receivedBytes);
                serverAnswer.Append(Encoding.UTF8.GetString(receivedBytes, 0, size));
            } 
            while (sender.Available > 0);

            GetMessageFromServer?.Invoke(serverAnswer.ToString());
            sender.Shutdown(SocketShutdown.Both);
            sender.Close();
            return serverAnswer.ToString();
        }

        /// <summary>
        /// Send messeage to server
        /// </summary>
        /// <param name="msg"></param>
        public void SendMsg(string msg)
        {
            var data = Encoding.UTF8.GetBytes(msg);
            sender.Connect(ipEndPoint);
            sender.Send(data);
            sender.Shutdown(SocketShutdown.Both);
            sender.Close();
        }
    }
}

