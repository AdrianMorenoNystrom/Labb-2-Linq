using LABB_2.Data;
using LABB_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LABB_2.Controllers
{
    public class StudentCoursesController : Controller
    {
        //Kontext för databas
        private readonly ApplicationDbContext _context;
        //Initiera kontexten
        public StudentCoursesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? courseId)
        {
            var courses = await _context.Courses.ToListAsync();
            var teachers = await _context.Teachers.ToListAsync();

            var query = from cl in _context.Courses
                        join t in _context.Teachers on cl.FkTeacherId equals t.TeacherId
                        join e in _context.Enrollments on cl.CourseId equals e.FkCourseId
                        join s in _context.Students on e.FkStudentId equals s.StudentId
                        select new { cl, s ,t};

            if (courseId.HasValue)
            {
                query = query.Where(x => x.cl.CourseId == courseId.Value);
            }

            var students = await query.Select(x => new StudentWithCourse
            {
                TeacherName = x.t.TeacherName,
                StudentName = x.s.StudentName,
                CourseName = x.cl.CourseName
            }).ToListAsync();

            string SelectedCourseName = null;
            if (courseId.HasValue)
            {
                var selectedCourse = await _context.Courses
                    .Where(c => c.CourseId == courseId.Value)
                    .FirstOrDefaultAsync();

                if (selectedCourse != null)
                {
                    SelectedCourseName = selectedCourse.CourseName;
                }
            }

            var viewModel = new StudentWithCourseViewModel
            {
                Courses = courses,
                Teachers = teachers,
                Students = students,
                SelectedCourseName = SelectedCourseName
            };
            return View(viewModel);
        }
    }
}
