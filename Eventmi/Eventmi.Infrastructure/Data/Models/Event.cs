using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Eventmi.Infrastructure.Data.Models
{
    /// <summary>
    /// Events
    /// </summary>
    [Comment("Events")]
    public class Event
    {
        /// <summary>
        /// Id of the event
        /// </summary>
        [Key]
        [Comment("Id of the event")]
        public int Id { get; set; }

        /// <summary>
        /// Name of the event
        /// </summary>
        [Required]
        [StringLength(50)]
        [Comment("Name of the event")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Start date and time of the event
        /// </summary>
        [Required]
        [Comment("Start date and time of the event")]
        public DateTime Start { get; set; }

        /// <summary>
        /// End date and time of the event
        /// </summary>
        [Required]
        [Comment("End date and time of the event")]
        public DateTime End { get; set; }

        /// <summary>
        /// Place of the event
        /// </summary>
        [Required]
        [StringLength(100)]
        [Comment("Place of the event")]
        public string Place { get; set; } = null!;
    }
}
