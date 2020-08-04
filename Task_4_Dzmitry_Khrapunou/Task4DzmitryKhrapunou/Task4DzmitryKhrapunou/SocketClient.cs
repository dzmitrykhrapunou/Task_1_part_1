using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Task4DzmitryKhrapunou.Entities;

namespace Task4DzmitryKhrapunou
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
        /// Client Message Handler
        /// </summary>
        ClientMessageHandler clientMessageHandler;

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
            clientMessageHandler = new ClientMessageHandler();

            EventSetup();
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
                throw new Exception("Connection was failed. " + exception);
            }           
        }

        /// <summary>
        /// Get message from server
        /// </summary>
        /// <param name="msg"></param>
        public string GetMessage()
        {
            byte[] buffer = new byte[1024];
            int size;
            var serverAnswer = new StringBuilder();

            do
            {
                size = sender.Receive(buffer);
                serverAnswer.Append(Encoding.UTF8.GetString(buffer, 0, size));
            } 
            while (sender.Available > 0);

            var answer = clientMessageHandler.InvokeMessageEvent(serverAnswer.ToString());
            Disconnect();

            return answer;
        }

        /// <summary>
        /// Send messeage to server
        /// </summary>
        /// <param name="msg"></param>
        public void SendMessage(ClientMessage msg)
        {
            byte[] data = Encoding.UTF8.GetBytes(msg.ClientName + "|" + msg.Content);
            sender.Connect(ipEndPoint);
            sender.Send(data);
            Disconnect();
        }

        /// <summary>
        /// Converter
        /// </summary>
        private void EventSetup()
        {            
            clientMessageHandler.MessageEvent += (string msg) =>
            {                
                StringBuilder str = new StringBuilder();
                string text = msg;

                for (int i = 0; i < text.Length; i++)
                {
                    bool isLower = char.IsLower(text[i]);
                    char letter = char.ToLower(text[i]);

                    if (clientMessageHandler.EnglishDictionary.ContainsKey(letter.ToString()))
                    {
                        string dictionaryKey;
                        char translationChar;

                        if (i + 3 <= text.Length)
                        {
                            dictionaryKey = text.Substring(i, 3);

                            if (clientMessageHandler.EnglishDictionary.TryGetValue(dictionaryKey, out translationChar))
                            {
                                if (!isLower)
                                    translationChar = char.ToLower(translationChar);

                                str.Append(translationChar);
                                i += 2;
                                continue;
                            }
                        }

                        if (i + 2 <= text.Length)
                        {
                            dictionaryKey = text.Substring(i, 2);

                            if (clientMessageHandler.EnglishDictionary.TryGetValue(dictionaryKey, out translationChar))
                            {
                                if (!isLower)
                                    translationChar = char.ToLower(translationChar);

                                str.Append(translationChar);
                                i++;
                                continue;
                            }
                        }

                        if (clientMessageHandler.EnglishDictionary.TryGetValue(letter.ToString(), out translationChar))
                        {
                            if (!isLower)
                                translationChar = char.ToLower(translationChar);

                            str.Append(translationChar);
                        }
                    }
                    else
                    {
                        if (clientMessageHandler.RussianDictionary.TryGetValue(letter, out string translationString))
                        {
                            if (isLower)
                            {
                                str.Append(translationString);
                            }
                            else
                            {
                                var buffer = new StringBuilder(translationString);
                                buffer[0] = char.ToUpper(buffer[0]);
                                str.Append(buffer);
                            }
                        }
                        else
                        {
                            str.Append(letter);
                        }
                    }
                }

                return str.ToString();               
            };
        }

        private void Disconnect()
        {
            sender.Shutdown(SocketShutdown.Both);
            sender.Close();
        }
    }
}

