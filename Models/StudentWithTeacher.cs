
namespace LABB_2.Models
{
    public class StudentWithTeacher
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string TeacherName { get; set; }
        public List<string> TeacherNames { get; internal set; }
    }
}
