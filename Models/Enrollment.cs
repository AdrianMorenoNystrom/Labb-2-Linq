using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace LABB_2.Models
{
    public enum Grade
    {
        A,
        B,
        C,
        D,
        E,
        F
    }
    public class Enrollment
    {
        [Key]
        public int EnrollmentId { get; set; }
        public Grade? Grade { get; set; }
        [ForeignKey("Course")]
        public int FkCourseId { get; set; }
        public virtual Course? Course { get; set; }
        [ForeignKey("Student")]
        public int FkStudentId { get; set; }
        public virtual Student? Student { get; set; }
    }
}
