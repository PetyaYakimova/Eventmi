using Microsoft.EntityFrameworkCore;

namespace Eventmi.Infrastructure.Data
{
    public class EventmiDbContext : DbContext
    {
        public EventmiDbContext()
        {

        }

        public EventmiDbContext(DbContextOptions<EventmiDbContext> options) : base(options)
        {

        }
    }
}
