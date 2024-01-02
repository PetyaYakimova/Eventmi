using Eventmi.Core.Contracts;
using Eventmi.Core.Models;
using Eventmi.Infrastructure.Data.Common;
using Eventmi.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Eventmi.Core.Services
{
    /// <summary>
    /// Event service
    /// </summary>
    public class EventService : IEventService
    {
        /// <summary>
        /// Access to the db
        /// </summary>
        private readonly IRepository repo;

        /// <summary>
        /// Initialize event service
        /// </summary>
        /// <param name="_repo"></param>
        public EventService(IRepository _repo)
        {
            repo = _repo;
        }

        /// <summary>
        /// Adds an event
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task AddAsync(EventDetailsModel model)
        {
            Event entity = new Event()
            {
                Name = model.Name,
                End = model.End,
                Start = model.Start,
                Place = model.Place
            };

            await repo.AddAsync(entity);
            await repo.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes an event
        /// </summary>
        /// <param name="id">id of the event</param>
        /// <returns></returns>
        public async Task DeleteAsync(int id)
        {
            await repo.DeleteAsync<Event>(id);
            await repo.SaveChangesAsync();
        }

        /// <summary>
        /// Gets all events
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<EventModel>> GetAllAsync()
        {
            return await repo.AllReadonly<Event>()
                .Select(e => new EventModel() 
                {
                    Id = e.Id,
                    Name = e.Name,
                    End = e.End,
                    Place = e.Place,
                    Start = e.Start
                })
                .OrderBy(e => e.Start)
                .ToListAsync();
        }

        /// <summary>
        /// Get one event by id
        /// </summary>
        /// <param name="id">id of the event</param>
        /// <returns></returns>
        public async Task<EventDetailsModel> GetEventAsync(int id)
        {
            var entity = await repo.GetByIdAsync<Event>(id);

            if (entity == null)
            {
                throw new ArgumentException("Invalid id", nameof(id));
            }

            return new EventDetailsModel()
            {
                Name = entity.Name,
                End = entity.End,
                Start = entity.Start,
                Place = entity.Place
            };
        }

        /// <summary>
        /// Updates an event
        /// </summary>
        /// <param name="model">event model</param>
        /// <returns></returns>
        public async Task UpdateAsync(EventModel model)
        {
            var entity = await repo.GetByIdAsync<Event>(model.Id);

            if (entity == null)
            {
                throw new ArgumentException("Invalid id", nameof(model.Id));
            }

            entity.Name = model.Name;
            entity.Place = model.Place;
            entity.End = model.End;
            entity.Start = model.Start;

            await repo.SaveChangesAsync();
        }
    }
}
