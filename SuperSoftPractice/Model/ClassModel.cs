using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperSoftPractice.Model
{
    [Table(name:"Class", Schema ="Std")]
    public class ClassModel : ModelBase
    {
        [Key]

        public long ClassId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

    }
}
