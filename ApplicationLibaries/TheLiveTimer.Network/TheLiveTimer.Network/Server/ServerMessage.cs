namespace TheLiveTimer.Network
{
    /// <summary>
    /// Server message to the timer clients
    /// </summary>
    public enum ServerMessage
    {
        /// <summary>
        /// Indicates that the server is ready to recieve client requests
        /// </summary>
        ServerReady = 1,

        /// <summary>
        /// Indicates that the request to be a client has been accepted
        /// </summary>
        ClientAccepted = 2,

        /// <summary>
        /// Inidicates that the request to be a client has been declined for various reasons
        /// </summary>
        ClientDeclined = 3,

        /// <summary>
        /// Indicates that the number of clients allowed has been exceeded. The client request is hence declined.
        /// </summary>
        ClientMax = 4,

        /// <summary>
        /// Verifies if the receiving client is still alive
        /// </summary>
        LivenessChecker = 10,
    }
}
