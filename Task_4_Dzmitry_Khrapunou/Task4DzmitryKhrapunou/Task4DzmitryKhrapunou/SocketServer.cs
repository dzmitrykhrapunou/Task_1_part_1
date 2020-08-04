using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Task4DzmitryKhrapunou.Entities;

namespace Task4DzmitryKhrapunou
{
    public class SocketServer
    {
        /// <summary>
        /// Local endpoint
        /// </summary>
        IPEndPoint ipEndPoint;

        /// <summary>
        /// Server socket
        /// </summary>
        Socket serverSocket;

        /// <summary>
        /// Server listener
        /// </summary>
        Socket serverListener;

        /// <summary>
        /// Server message handler
        /// </summary>
        ServerMessageHandler serverMessageHandler;

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

            serverMessageHandler = new ServerMessageHandler();
            ipEndPoint = new IPEndPoint(IPAddress.Parse(ipAdress), port);
            serverListener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverListener.Bind(ipEndPoint);

            EventSetup();
        }

        /// <summary>
        /// Setup event
        /// </summary>
        private void EventSetup()
        {
            serverMessageHandler.MessageEvent += (ClientMessage message) =>
            {
                serverMessageHandler.messages.Add(message);
            };
        }

        /// <summary>
        /// Get all client messages
        /// </summary>
        /// <returns></returns>
        public List<ClientMessage> GetAllMessages()
        {
            return serverMessageHandler.messages;
        }

        public void SendMessage(ClientMessage msg)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(msg.ToString());
            serverSocket.Send(bytes);
        }

        /// <summary>
        /// Get message
        /// </summary>
        /// <returns></returns>
        public ClientMessage GetMessage()
        {
            string[] data = GetString().Split('|');
            string clientName = data[0];
            string msgText = data[1];

            ClientMessage message = new ClientMessage(clientName, msgText);
            serverMessageHandler.InvokeMessageEvent(message);

            return message;
        }

        /// <summary>
        /// Method waiting and get message from clients
        /// </summary>        
        public void ListenClient()
        {
            if (serverListener != null)
            {
                serverListener.Listen(1);
                serverSocket = serverListener.Accept();
            }
            else
            {
                throw new Exception("The server listener was not created");
            }

            while (true)
            {
                byte[] buffer = new byte[1024];
                int size;

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

        private string GetString()
        {
            byte[] data = new byte[1024];
            string result = null;
            int number;

            if (serverSocket.Available > 0)
            {
                number = serverSocket.Receive(data);
                result = Encoding.UTF8.GetString(data, 0, number);
            }

            return result;
        }
    }
}
