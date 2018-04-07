namespace TheLiveTimer.Network
{
    /// <summary>
    /// Client message to the Timer Server
    /// </summary>
    public enum ClientMessage
    {
        /// <summary>
        /// Indicates a request to become a client to the receiving server
        /// </summary>
        ClientRequest = 1,
    }
}
