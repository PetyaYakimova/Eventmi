using Eventmi.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Eventmi.Infrastructure.Data
{
    /// <summary>
    /// Db context
    /// </summary>
    public class EventmiDbContext : DbContext
    {
        /// <summary>
        /// Creates db context without settings
        /// </summary>
        public EventmiDbContext()
        {

        }

        /// <summary>
        /// Creates db context with options
        /// </summary>
        /// <param name="options">Db context options</param>
        public EventmiDbContext(DbContextOptions<EventmiDbContext> options) : base(options)
        {

        }

        /// <summary>
        /// Events table
        /// </summary>
        public DbSet<Event> Events { get; set; } = null!;
    }
}
