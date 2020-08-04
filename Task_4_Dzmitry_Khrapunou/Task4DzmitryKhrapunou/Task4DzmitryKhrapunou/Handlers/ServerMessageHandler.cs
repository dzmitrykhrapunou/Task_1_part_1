using System.Collections.Generic;
using Task4DzmitryKhrapunou.Entities;

namespace Task4DzmitryKhrapunou
{
    public class ServerMessageHandler
    {
        /// <summary>
        /// Delegate
        /// </summary>
        public delegate void GetMessage(ClientMessage message);

        /// <summary>
        /// Event
        /// </summary>
        public event GetMessage MessageEvent;

        /// <summary>
        /// Invoke event
        /// </summary>
        /// <param name="message">Message</param>
        public void InvokeMessageEvent(ClientMessage message)
        {
            MessageEvent(message);
        }

        /// <summary>
        /// List of client messages
        /// </summary>
        public List<ClientMessage> messages = new List<ClientMessage>();
    }
}
