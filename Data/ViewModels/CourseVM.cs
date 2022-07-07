using eTutorials.Data;
using eTutorials.Data.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eTutorials.Models
{
    public class CourseVM
    {
        public int Id { get; set; }
        public string LogoUrl { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public CourseCategory CourseCategory { get; set; }

        //Relations
        public List<int> TeacherIds { get; set; }
        public int CompanyId { get; set; }
        public int AuthorId { get; set; }
    }
}
