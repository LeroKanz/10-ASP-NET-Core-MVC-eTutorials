using eTutorials.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTutorials.Data.ViewModels
{
    public class CoursesDropDownListVM
    {
        public CoursesDropDownListVM()
        {
            Authors = new List<Author>();
            Companies = new List<Company>();
            Teachers = new List<Teacher>();
        }

        public List<Author> Authors { get; set; }
        public List<Company> Companies { get; set; }
        public List<Teacher> Teachers { get; set; }
    }
}
