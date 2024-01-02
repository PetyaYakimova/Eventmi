using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Eventmi.Core.Models
{
    /// <summary>
    /// Event model with Id
    /// </summary>
    public class EventModel
    {
        /// <summary>
        /// Id of the event
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the event
        /// </summary>
        [Display(Name = "Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "The field {0} is required.")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "{0} should be between {2} and {1} characters.")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Start date and time of the event
        /// </summary>
        [Display(Name = "Start")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "The field {0} is required.")]
        public DateTime Start { get; set; }

        /// <summary>
        /// End date and time of the event
        /// </summary>
        [Display(Name = "End")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "The field {0} is required.")]
        public DateTime End { get; set; }

        /// <summary>
        /// Place of the event
        /// </summary>
        [Display(Name = "Place")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "The field {0} is required.")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "{0} should be between {2} and {1} characters.")]
        public string Place { get; set; } = null!;
    }
}
