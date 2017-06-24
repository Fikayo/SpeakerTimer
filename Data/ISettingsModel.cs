namespace SpeakerTimer.Data
{
    using System.Collections.Generic;
    using SpeakerTimer.Application;

    public interface ISettingsModel<T> where T : ITimerSettings
    {
        /// <summary>
        /// Returns a list of all timers stored in this model.
        /// </summary>
        /// <returns>All saved timers</returns>
        List<T> FetchAll();

        /// <summary>
        /// Fetches the timer with the given Id if it exists, else null.
        /// </summary>
        /// <param name="timerId">The required timer Id</param>
        /// <returns>The desired timer</returns>
        T Fetch(int timerId);

        /// <summary>
        /// Updates the given timer or inserts if its id doesn't exist.
        /// </summary>
        /// <param name="timer">The timer to save</param>
        /// <returns>Returns the saved timer with an updated Id if it was inserted.</returns>
        T Save(T timer);

        /// <summary>
        /// Deletes the timer with the given timer Id
        /// </summary>
        /// <param name="timerId">The required timer Id</param>
        /// <returns>True if successful, else false.</returns>
        bool Delete(int timerId);
    }
}
