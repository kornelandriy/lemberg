using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lemberg.Models
{
    public class Mark
    {
        [Key]
        [ForeignKey("Person")]
        public int Id { get; set; }

        [StringLength(150)]
        public string Value { get; set; }

        public People People { get; set; }
    }
}