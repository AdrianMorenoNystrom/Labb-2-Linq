using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LABB_2.Models
{
    public class CourseClass
    {
        [Key]
        public int CourseClassId { get; set; }
        public string ClassName { get; set; }

        [ForeignKey("Teacher")]
        public int FkTeacherId { get; set; }
        public Teacher? Teacher { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}
