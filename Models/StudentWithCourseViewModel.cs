namespace LABB_2.Models
{
    public class StudentWithCourseViewModel
    {
        public IEnumerable<StudentWithCourse> Students { get; set; }
        public IEnumerable<Course> Courses { get; set; }
        public IEnumerable<Teacher> Teachers { get; set; }


        public string SelectedCourseName { get; set; }
    }
}
