namespace TheLiveTimer.Network
{
    /// <summary>
    /// Server message to the timer clients
    /// </summary>
    public enum ServerMessage
    {
        /// <summary>
        /// Indicates that the request to be a client has been accepted
        /// </summary>
        ClientAccepted = 1,

        /// <summary>
        /// Inidicates that the request to be a client has been declined for various reasons
        /// </summary>
        ClientDeclined = 2,

        /// <summary>
        /// Indicates that the number of clients allowed has been exceeded. The client request is hence declined.
        /// </summary>
        ClientMax = 3,
    }
}
