using eTutorials.Data.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTutorials.Models
{
    public class Company : IEntityForRepo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string LogoUrl { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        //Relations
        public List<Course> Courses { get; set; }
    }
}
