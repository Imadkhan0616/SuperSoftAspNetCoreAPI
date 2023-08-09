using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperSoftPractice.Model
{
    [Table(name:"Section", Schema ="Std")]
    public class SectionModel : ModelBase
    {
        [Key]
        public long SectionId { get; set; }

        [Required]
        public string SectionName { get; set; }

    }
}
