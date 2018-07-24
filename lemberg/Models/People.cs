using System.ComponentModel.DataAnnotations;

namespace lemberg.Models
{
    public class People
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        public Mark Mark { get; set; }
    }
}