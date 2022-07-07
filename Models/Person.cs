using eTutorials.Data.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTutorials.Models
{
    public class Person : IEntityForRepo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Logo")]
        public string LogoUrl { get; set; }
        [Required]
        [Display(Name = "Full Name")]
        [StringLength(70, MinimumLength = 2)]
        public string FullName { get; set; }
        [Required]
        [StringLength(500, MinimumLength = 15)]
        public string Experience { get; set; }
    }
}
