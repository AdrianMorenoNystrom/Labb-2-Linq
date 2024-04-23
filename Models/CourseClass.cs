using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LABB_2.Models
{
    public class CourseClass
    {
        [Key]
        public int CourseClassId { get; set; }
        [ForeignKey("Course")]
        public int FkCourseId { get; set; }
        public virtual Course? Course { get; set; }

        [ForeignKey("Teacher")]
        public int FkTeacherId { get; set; }
        public virtual Teacher? Teacher { get; set; }
    }
}
