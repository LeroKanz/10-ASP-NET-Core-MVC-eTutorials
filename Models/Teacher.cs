using eTutorials.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTutorials.Models
{
    public class Teacher : Person
    {
        //Relations
        public List<Teacher_Course> Teachers_Courses { get; set; }
    }
}
