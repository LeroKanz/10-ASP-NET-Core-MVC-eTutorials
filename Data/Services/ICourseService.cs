using eTutorials.Data.Repositories;
using eTutorials.Data.ViewModels;
using eTutorials.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTutorials.Data.Services
{
    public interface ICourseService : IEntityRepository<Course>
    {
        Task<Course> GetCourseByIdAsync(int id);
        Task<CoursesDropDownListVM> GetCoursesDropDownListVM();
        Task AddNewCourseAsync(CourseVM courseVM);
        Task UpdateCourseAsync(CourseVM courseVM);
    }
}
