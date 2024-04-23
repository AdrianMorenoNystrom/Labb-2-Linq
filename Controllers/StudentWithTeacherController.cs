using LABB_2.Data;
using LABB_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LABB_2.Controllers
{
    public class StudentWithTeacherController : Controller
    {
        //Kontext för databas
        private readonly ApplicationDbContext _context;
        //Initiera kontexten
        public StudentWithTeacherController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? teacherId)
        {
            // Retrieve the list of teachers
            var teachers = await _context.Teachers.ToListAsync();

            // Start with querying students
            var query = from s in _context.Students
                        join e in _context.Enrollments on s.StudentId equals e.FkStudentId
                        join c in _context.Courses on e.FkCourseId equals c.CourseId
                        join tl in _context.Teachers on c.CourseId equals tl.TeacherId
                        select new { Teacher = tl, Student = s };

            // Filter by selected teacher if provided
            if (teacherId.HasValue)
            {
                query = query.Where(x => x.Teacher.TeacherId == teacherId.Value);
            }

            // Project the result to ViewModel
            var studentTeacherViewModels = await query.Select(x => new StudentWithTeacher
            {
                TeacherName = x.Teacher.TeacherName,
                StudentName = x.Student.StudentName
            }).ToListAsync();

            // Retrieve the name of the selected teacher
            string selectedTeacherName = null;
            if (teacherId.HasValue)
            {
                var selectedTeacher = await _context.Teachers
                    .Where(t => t.TeacherId == teacherId.Value)
                    .FirstOrDefaultAsync();

                if (selectedTeacher != null)
                {
                    selectedTeacherName = selectedTeacher.TeacherName;
                }
            }

            // Prepare the ViewModel
            var viewModel = new StudentWithTeacherViewModel
            {
                Teachers = teachers,
                SelectedTeacherName = selectedTeacherName
            };

            return View(viewModel);
        }
    }
}
