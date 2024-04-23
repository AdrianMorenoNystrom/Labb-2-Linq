using System.ComponentModel.DataAnnotations;

namespace LABB_2.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public virtual ICollection<Enrollment>? Enrollments { get; set; }
    }
}
