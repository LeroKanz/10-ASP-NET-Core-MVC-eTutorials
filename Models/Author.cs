using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTutorials.Models
{
    public class Author : Person
    {
        //Relations
        public List<Course> Courses { get; set; }
    }
}
