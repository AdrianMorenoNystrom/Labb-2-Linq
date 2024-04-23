namespace LABB_2.Models
{
    public class TeacherWithCourseViewModel
    {
        public IEnumerable<TeacherWithCourse> Teachers { get; set; }
        public IEnumerable<Course> Courses { get; set; }
        public string SelectedCourseName { get; set; }
    }
}
