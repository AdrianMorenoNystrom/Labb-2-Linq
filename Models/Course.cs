using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LABB_2.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        [ForeignKey("Teacher")]
        public int FkTeacherId { get; set; }
        public virtual Teacher? Teacher { get; set; }
        public virtual ICollection<Enrollment>? Enrollments { get; set; }
    }
}
