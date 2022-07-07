using eTutorials.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTutorials.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher_Course>().HasKey(teacherCourse => new
            {
                teacherCourse.TeatherId,
                teacherCourse.CourseId
            });

            modelBuilder.Entity<Teacher_Course>().HasOne(teacher => teacher.Teacher)
                .WithMany(teacherCourse => teacherCourse.Teachers_Courses).HasForeignKey(teacher => teacher.TeatherId);

            modelBuilder.Entity<Teacher_Course>().HasOne(course => course.Course)
                .WithMany(teacherCourse => teacherCourse.Teachers_Courses).HasForeignKey(course => course.CourseId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Teacher_Course> Teachers_Courses { get; set; }
        
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
