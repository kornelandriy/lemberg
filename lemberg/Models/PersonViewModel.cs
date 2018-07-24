using System.ComponentModel.DataAnnotations;

namespace lemberg.Models
{
    public class PersonViewModel
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(150)]
        public string MarkValue { get; set; }

        public int ReturnPage { get; set; }
    }
}