using NUnit.Framework;
using System;
using System.Threading;
using Task4DzmitryKhrapunou;
using Task4DzmitryKhrapunou.Entities;

namespace NUnitTests
{
    [TestFixture]
    public class Tests
    {       
        [Test]
        public void Translate_TranslateMessage_ReturnsNewMessage()
        {            
            string expectedAnswer = null;
            string actualAnswer = null;
            bool wait = true;

            SocketServer server = new SocketServer(1408, "127.0.0.1");

            void ServerRun()
            {
                try
                {
                    server.ListenClient();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                ClientMessage msg = server.GetMessage();
                wait = false;
                server.SendMessage(msg);
                
            }
            
            Thread threadServer = new Thread(new ThreadStart(ServerRun));
            threadServer.Start();

            string client = "Vasya Pupkin";
            SocketClient clientSocket = new SocketClient(1408, "127.0.0.1");
            clientSocket.Connect();
            var message = new ClientMessage(client, "Hello");

            expectedAnswer = "цлиент нaме: вaсya пупкин, мессaге: xелло";
            clientSocket.SendMessage(message);

            while (wait);

            Thread.Sleep(1000);

            actualAnswer = clientSocket.GetMessage();                    

            Assert.NotNull(expectedAnswer);
            Assert.NotNull(actualAnswer);
            Assert.AreEqual(expectedAnswer, actualAnswer);
        }        
    }
}