using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LABB_2.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        [ForeignKey("Teachers")]
        public int FkTeacherId { get; set; }
        public Teacher? Teacher { get; set; }
        public virtual ICollection<Enrollment>? Enrollments { get; set; }
    }
}