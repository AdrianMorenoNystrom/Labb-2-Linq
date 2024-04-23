namespace LABB_2.Models
{
    public class StudentWithTeacherViewModel
    {
        public IEnumerable<StudentWithTeacher> Students { get; set; }
        public IEnumerable<Teacher> Teachers { get; set; }

        public string SelectedTeacherName { get; set; }
    }
}
