namespace TheLiveTimer.Network
{
    /// <summary>
    /// Timer commands for transmission over the network
    /// </summary>
    public enum TimerCommand
    {
        /// <summary>
        /// Notifies what a second has passsed
        /// </summary>
        TimerSecondElapsed = 1,

        /// <summary>
        /// Notifies of an update to the time of the timer
        /// </summary>
        TimeUpdated = 2,

        /// <summary>
        /// Indicates that the timer has started
        /// </summary>
        TimeStarted = 3,

        /// <summary>
        /// Indicates that the timer has been paused
        /// </summary>
        TimePaused = 4,

        /// <summary>
        /// Indicates that the timer has been stopped
        /// </summary>
        TimeStopped = 5,

        /// <summary>
        /// Indiciates that the time of the timer has expired
        /// </summary>
        TimeExpired = 6,

        /// <summary>
        /// Notifies to start blinking the timer
        /// </summary>
        StartBlinking = 7,

        /// <summary>
        /// Notifies to stop blinking the timer
        /// </summary>
        StopBlinking = 8,

        /// <summary>
        /// Notifies that a broadcast message is ready for display
        /// </summary>
        BroadcastReady = 9,

        /// <summary>
        /// Notifies that the broadcast is over
        /// </summary>
        BroadcastOver = 10,

        /// <summary>
        /// Notifies of a change of the timer settings.
        /// </summary>
        SettingsUpdated = 11,

        /* Request commands from 17 - */

        /// <summary>
        /// Notifies the server of a request to start the timer
        /// </summary>
        StartRequest = 17,

        /// <summary>
        /// NOtifies the server of a request to pause the timer
        /// </summary>
        PauseRequest = 18,

        /// <summary>
        /// Notifies the server of a request to stop the timer
        /// </summary>
        StopRequest = 19,

        /// <summary>
        /// Notifies the server of a request to reset the timer
        /// </summary>
        ResetRequest = 19,
    }
}