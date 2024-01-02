using Eventmi.Core.Models;

namespace Eventmi.Core.Contracts
{
    /// <summary>
    /// Service for managing events
    /// </summary>
    public interface IEventService
    {
        /// <summary>
        /// Add event
        /// </summary>
        /// <param name="model">event detail model</param>
        /// <returns></returns>
        Task AddAsync(EventDetailsModel model);

        /// <summary>
        /// Delete event
        /// </summary>
        /// <param name="id">id of the event</param>
        /// <returns></returns>
        Task DeleteAsync(int id);

        /// <summary>
        /// Update event
        /// </summary>
        /// <param name="model">event model</param>
        /// <returns></returns>
        Task UpdateAsync(EventModel model);

        /// <summary>
        /// Preview all events
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<EventModel>> GetAllAsync();

        /// <summary>
        /// Preview one event
        /// </summary>
        /// <param name="id">id of the event</param>
        /// <returns></returns>
        Task<EventDetailsModel> GetEventAsync(int id);
    }
}
