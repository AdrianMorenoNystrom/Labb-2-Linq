using System.ComponentModel.DataAnnotations;

namespace LABB_2.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }

        public List<Course>? Courses { get; set; }
    }
}
