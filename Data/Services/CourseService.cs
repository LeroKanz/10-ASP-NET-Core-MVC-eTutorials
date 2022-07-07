using eTutorials.Data.Repositories;
using eTutorials.Data.ViewModels;
using eTutorials.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTutorials.Data.Services
{
    public class CourseService : EntityRepository<Course>, ICourseService
    {
        private readonly AppDbContext _context;
        public CourseService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewCourseAsync(CourseVM courseVM)
        {
            var result = new Course()
            {
                Name = courseVM.Name, 
                Description = courseVM.Description,
                Price = courseVM.Price,
                LogoUrl = courseVM.LogoUrl,
                StartDate = courseVM.StartDate,
                EndDate = courseVM.EndDate,
                CompanyId = courseVM.CompanyId,
                AuthorId = courseVM.AuthorId,
                CourseCategory = courseVM.CourseCategory
            };

            await _context.Courses.AddAsync(result);
            await _context.SaveChangesAsync();

            //adding teacher
            foreach (var teacherId in courseVM.TeacherIds)
            {
                var teacherCourse = new Teacher_Course()
                {
                    CourseId = result.Id,
                    TeatherId = teacherId
                };
                await _context.Teachers_Courses.AddAsync(teacherCourse);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Course> GetCourseByIdAsync(int id)
        {
            var result = await _context.Courses
                .Include(c => c.Company)
                .Include(a => a.Author)
                .Include(tc => tc.Teachers_Courses)
                .ThenInclude(t => t.Teacher)
                .FirstOrDefaultAsync(i => i.Id == id);
            return result;
        }

        public async Task<CoursesDropDownListVM> GetCoursesDropDownListVM()
        {
            var result = new CoursesDropDownListVM()
            {
                Teachers = await _context.Teachers.OrderBy(t => t.FullName).ToListAsync(),
                Companies = await _context.Companies.OrderBy(c => c.Name).ToListAsync(),
                Authors = await _context.Authors.OrderBy(a => a.FullName).ToListAsync()
            };
            
            return result;
        }

        public async Task UpdateCourseAsync(CourseVM courseVM)
        {
            var dbCourse = await _context.Courses.FirstOrDefaultAsync(c => c.Id == courseVM.Id);

            if (dbCourse != null)
            {
                dbCourse.Name = courseVM.Name;
                dbCourse.Description = courseVM.Description;
                dbCourse.Price = courseVM.Price;
                dbCourse.LogoUrl = courseVM.LogoUrl;
                dbCourse.StartDate = courseVM.StartDate;
                dbCourse.EndDate = courseVM.EndDate;
                dbCourse.CompanyId = courseVM.CompanyId;
                dbCourse.AuthorId = courseVM.AuthorId;
                dbCourse.CourseCategory = courseVM.CourseCategory;
                await _context.SaveChangesAsync();
            }

            var existingTeacher = _context.Teachers_Courses.Where(tC => tC.CourseId == courseVM.Id).ToList();
            _context.Teachers_Courses.RemoveRange(existingTeacher);
            await _context.SaveChangesAsync();

            //adding teacher
            foreach (var teacherId in courseVM.TeacherIds)
            {
                var teacherCourse = new Teacher_Course()
                {
                    CourseId = courseVM.Id,
                    TeatherId = teacherId
                };
                await _context.Teachers_Courses.AddAsync(teacherCourse);
            }
            await _context.SaveChangesAsync();
        }
    }
}
