namespace Task4DzmitryKhrapunou.Entities
{
    public class ClientMessage
    {
        /// <summary>
        /// Client name
        /// </summary>
        public string ClientName { get; set; }

        /// <summary>
        /// Message text
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Initializes a new instance of the ClientMessage class
        /// </summary>
        /// <param name="content">Message text</param>
        /// <param name="client">Client name</param>
        public ClientMessage(string clientName, string content)
        {
            ClientName = clientName;
            Content = content;
        }

        /// <summary>
        /// Returns a string that describes current object.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("Client name: {0}, Message: {1}", ClientName, Content);
        }
    }
}
