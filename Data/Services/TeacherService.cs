using eTutorials.Data.Repositories;
using eTutorials.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTutorials.Data.Services
{
    public class TeacherService : EntityRepository<Teacher>, ITeacherService
    {
        public TeacherService(AppDbContext context) : base(context) { }
    }
}
