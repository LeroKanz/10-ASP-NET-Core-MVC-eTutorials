using eTutorials.Data;
using eTutorials.Data.Services;
using eTutorials.Data.StaticClasses;
using eTutorials.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTutorials.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class TeacherController : Controller
    {
        private readonly ITeacherService _service;

        public TeacherController(ITeacherService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Teachers()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }
        
        //GET
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName, LogoUrl, Experience")]Teacher teacher)
        {
            if (!ModelState.IsValid)
            {
                return View(teacher);
            }
            await _service.AddAsync(teacher);
            return RedirectToAction(nameof(Teachers));            
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null) return View("NotFound");
            return View(result);
        }

        //GET
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null) return View("NotFound");
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, FullName, LogoUrl, Experience")] Teacher teacher)
        {
            if (!ModelState.IsValid)
            {
                return View(teacher);
            }
            await _service.UpdateAsync(id, teacher);
            return RedirectToAction(nameof(Teachers));
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
            return RedirectToAction(nameof(Teachers));
        }
    }
}
