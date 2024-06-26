﻿using LABB_2.Data;
using LABB_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LABB_2.Controllers
{
    public class TeacherCoursesController : Controller
    {
        //Kontext för databas
        private readonly ApplicationDbContext _context;
        //Initiera kontexten
        public TeacherCoursesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? courseId)
        {
            var courses = await _context.Courses.ToListAsync();

            var query = from cl in _context.Courses
                        join t in _context.Teachers on cl.FkTeacherId equals t.TeacherId
                        select new { cl, t};

            if (courseId.HasValue)
            {
                query = query.Where(x => x.cl.CourseId == courseId.Value);
            }

            var teachers = await query.Select(x => new TeacherWithCourse
            {
                TeacherName = x.t.TeacherName,
                CourseName = x.cl.CourseName
            }).ToListAsync();

            string SelectedCourseName = null;
            if (courseId.HasValue)
            {
                var selectedCourse = await _context.Courses
                    .Where(c => c.CourseId == courseId.Value)
                    .FirstOrDefaultAsync();

                if(selectedCourse != null)
                {
                    SelectedCourseName = selectedCourse.CourseName;
                }
            }

            var viewModel = new TeacherWithCourseViewModel
            {
                Courses = courses,
                Teachers = teachers,
                SelectedCourseName = SelectedCourseName
            };
            return View(viewModel);
        }
    }
}
