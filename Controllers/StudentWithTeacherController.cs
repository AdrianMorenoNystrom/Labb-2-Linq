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

        public async Task<IActionResult> Index(int? StudentId)
        {
            // Retrieve the list of teachers
            var students = await _context.Students.ToListAsync();

            // Start with querying students
            var query = from t in _context.Teachers
                        join c in _context.Courses on t.TeacherId equals c.FkTeacherId
                        join e in _context.Enrollments on c.CourseId equals e.FkCourseId
                        join s in _context.Students on e.FkStudentId equals s.StudentId
                        select new { s, t };
            //var query = from s in _context.Students
            //            join e in _context.Enrollments on s.StudentId equals e.FkStudentId
            //            join c in _context.Courses on e.FkCourseId equals c.CourseId
            //            join tl in _context.Teachers on c.FkTeacherId equals tl.TeacherId
            //            select new { tl,  s };


            // Filter by selected teacher if provided
            if (StudentId.HasValue)
            {
                query = query.Where(x => x.s.StudentId == StudentId.Value);
            }

            // Project the result to ViewModel
            var studentTeacherViewModels = await query.Select(x => new StudentWithTeacher
            {
                StudentName = x.s.StudentName,
                StudentId = x.s.StudentId,
                TeacherName = x.t.TeacherName,
            }).ToListAsync();

            // Retrieve the name of the selected teacher
            string selectedStudentName = null;
            if (StudentId.HasValue)
            {
                var selectedStudent = await _context.Students
                    .Where(s => s.StudentId == StudentId.Value)
                    .FirstOrDefaultAsync();

                if (selectedStudent != null)
                {
                    selectedStudentName = selectedStudent.StudentName;
                }
            }

            // Prepare the ViewModel
            var viewModel = new StudentWithTeacherViewModel
            {
                Students = studentTeacherViewModels,
                SelectedStudentName = selectedStudentName
            };

            return View(viewModel);
        }
    }
}
