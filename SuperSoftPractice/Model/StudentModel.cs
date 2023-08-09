using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperSoftPractice.Model
{
    [Table(name:"Student", Schema = "Std")]
    public class StudentModel : ModelBase
    {
        [Key]
        [Required]

        public long StudentId { get; set; }

        [Required]

        public string Name { get; set; }

        [Required]

        public string Address { get; set; }

        #region One-to-One Relationship

        [Required]
        public long ClassId { get; set; }

        public long SectionId { get; set; }

        public SectionModel Section { get; set; }

        public ClassModel Class { get; set; }

        #endregion
    }
}
