using eTutorials.Data;
using eTutorials.Data.Services;
using eTutorials.Data.StaticClasses;
using eTutorials.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTutorials.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class CourseController : Controller
    {
        private readonly ICourseService _service;

        public CourseController(ICourseService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Courses()
        {
            var result = await _service.GetAllAsync(c => c.Company);
            return View(result);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var result = await _service.GetAllAsync(c => c.Company);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = result.Where(c => c.Name.ToLower().Contains(searchString.ToLower()) || c.Description.ToLower().Contains(searchString.ToLower())).ToList();
                return View("Courses", filteredResult);
            }

            return View("Courses", result);
        }

        //GET
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var result = await _service.GetCourseByIdAsync(id);
            if (result == null) return View("NotFound");
            return View(result);
        }

        //GET
        public async Task<IActionResult> Create()
        {
            var result = await _service.GetCoursesDropDownListVM();

            ViewBag.Companies = new SelectList(result.Companies, "Id", "Name");
            ViewBag.Authors = new SelectList(result.Authors, "Id", "FullName");
            ViewBag.Teachers = new SelectList(result.Teachers, "Id", "FullName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CourseVM course)
        {
            if (!ModelState.IsValid)
            {
                var result = await _service.GetCoursesDropDownListVM();

                ViewBag.Companies = new SelectList(result.Companies, "Id", "Name");
                ViewBag.Authors = new SelectList(result.Authors, "Id", "FullName");
                ViewBag.Teachers = new SelectList(result.Teachers, "Id", "FullName");

                return View(course);
            }
            await _service.AddNewCourseAsync(course);
            return RedirectToAction(nameof(Courses));
        }

        //GET
        public async Task<IActionResult> Edit(int id)
        {
            var ditails = await _service.GetCourseByIdAsync(id);
            if (ditails == null) return View("NotFound");

            var response = new CourseVM()
            {
                Id = ditails.Id,
                Name = ditails.Name,
                Description = ditails.Description,
                Price = ditails.Price,
                LogoUrl = ditails.LogoUrl,
                StartDate = ditails.StartDate,
                EndDate = ditails.EndDate,
                CourseCategory = ditails.CourseCategory,
                CompanyId = ditails.CompanyId,
                AuthorId = ditails.AuthorId,
                TeacherIds = ditails.Teachers_Courses.Select(t => t.TeatherId).ToList()
            };

            var dropDown = await _service.GetCoursesDropDownListVM();
            ViewBag.Companies = new SelectList(dropDown.Companies, "Id", "Name");
            ViewBag.Authors = new SelectList(dropDown.Authors, "Id", "FullName");
            ViewBag.Teachers = new SelectList(dropDown.Teachers, "Id", "FullName");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, CourseVM course)
        {
            if (id != course.Id)
            {
                return View("NotFound");
            }
            
            if (!ModelState.IsValid)
            {
                var result = await _service.GetCoursesDropDownListVM();

                ViewBag.Companies = new SelectList(result.Companies, "Id", "Name");
                ViewBag.Authors = new SelectList(result.Authors, "Id", "FullName");
                ViewBag.Teachers = new SelectList(result.Teachers, "Id", "FullName");

                return View(course);
            }
            await _service.UpdateCourseAsync(course);
            return RedirectToAction(nameof(Courses));
        }

        //GET
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null) return View("NotFound");
            return View(result);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Courses));
        }
    }
}
