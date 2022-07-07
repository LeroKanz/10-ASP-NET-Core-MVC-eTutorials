using eTutorials.Data.Repositories;
using eTutorials.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTutorials.Data.Services
{
    public class AuthorService : EntityRepository<Author>, IAuthorService
    {
        public AuthorService(AppDbContext context) : base(context)
        {

        }
    }
}
