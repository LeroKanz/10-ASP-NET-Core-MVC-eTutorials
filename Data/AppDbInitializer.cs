using eTutorials.Data.StaticClasses;
using eTutorials.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTutorials.Data
{
    public class AppDbInitializer
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScoup = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScoup.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                if (!context.Companies.Any())
                {
                    context.Companies.AddRange(new List<Company>()
                    {
                        new Company()
                        {
                            Name = "EPAM",
                            LogoUrl = "/Img/EPAM.jpg",
                            Description = "Very good company for real developers!"
                        },
                        new Company()
                        {
                            Name = "ISsoft",
                            LogoUrl = "/Img/ISsoft.jpg",
                            Description = "Good company for real developers!"
                        },
                        new Company()
                        {
                            Name = "Wargaming",
                            LogoUrl = "/Img/WG.jpg",
                            Description = "Nice company for real developers!"
                        },
                        new Company()
                        {
                            Name = "iTechArt",
                            LogoUrl = "/Img/iTechArt.jpg",
                            Description = "Normal company for junior developers!"
                        },
                        new Company()
                        {
                            Name = "ITransition",
                            LogoUrl = "/Img/itransition.jpg",
                            Description = "You should think twice before apply for a job!"
                        },
                    });
                    context.SaveChanges();
                }

                if (!context.Teachers.Any())
                {
                    context.Teachers.AddRange(new List<Teacher>()
                    {
                        new Teacher()
                        {
                            FullName = "Maria Krasivaia",
                            LogoUrl = "/Img/Teachers/Epam-2.jpg",
                            Experience = "Working with all of her beauty for EPAM for the last two years."
                        },                        
                        new Teacher()
                        {

                            FullName = "Rita Umeevyh",
                            LogoUrl = "/Img/Teachers/Is-soft-1.jpg",
                            Experience = "Working with gorgeous smile for ISsoft for the last three years."
                        },
                        new Teacher()
                        {
                            FullName = "Alexandr Bolshih",
                            LogoUrl = "/Img/Teachers/WG-2.jpg",
                            Experience = "Working for Wargaming for one year."
                        },
                        new Teacher()
                        {
                            FullName = "Andrey Dnokapalski",
                            LogoUrl = "/Img/Teachers/ITechArt-2.jpg",
                            Experience = "Working for iTechArt, but willing to leave soon."
                        },
                        new Teacher()
                        {
                            FullName = "Vasiliy Rak",
                            LogoUrl = "/Img/Teachers/Itransition-1.jpg",
                            Experience = "Working for ITransition from time to time and kind of somehow."
                        },
                        new Teacher()
                        {
                            FullName = "Evgen Staroumny",
                            LogoUrl = "/Img/Teachers/Epam-1.jpg",
                            Experience = "Working for EPAM for the last forty years and knows a lot of stuff on programming issues."
                        },
                        new Teacher()
                        {
                            FullName = "Oleg Krevetko",
                            LogoUrl = "/Img/Teachers/Itransition-2.jpg",
                            Experience = "Doesn't know, what the \"Working for ITransition\" mean, but still works somehow."
                        },
                        new Teacher()
                        {

                            FullName = "Andrey Ponimavski",
                            LogoUrl = "/Img/Teachers/Is-soft-2.jpg",
                            Experience = "Working whith fun but properly for ISsoft for the last three years."
                        },
                        new Teacher()
                        {
                            FullName = "Xzkus Ktokus",
                            LogoUrl = "/Img/Teachers/ITechArt-1.jpg",
                            Experience = "Working for iTechArt, but willing to leave soon too, as a previous one."
                        },
                        new Teacher()
                        {
                            FullName = "Igor Smely",
                            LogoUrl = "/Img/Teachers/WG-1.jpg",
                            Experience = "Working for Wargaming for five years like a leader."
                        },
                    });
                    context.SaveChanges();
                }

                if (!context.Authors.Any())
                {
                    context.Authors.AddRange(new List<Author>()
                    {                        
                        new Author()
                        {
                            FullName = "Natalia Irub",
                            LogoUrl = "/Img/EPAM.jpg",
                            Experience = "Working for EPAM 3.5 years."
                        },
                        new Author()
                        {

                            FullName = "Dmitry Ruta",
                            LogoUrl = "/Img/ISsoft.jpg",
                            Experience = "Working for ISsoft 2 years."
                        },
                        new Author()
                        {
                            FullName = "Alexandr Alert",
                            LogoUrl = "/Img/WG.jpg",
                            Experience = "Working for Wargaming 4.5 years."
                        },
                        new Author()
                        {
                            FullName = "Andrey Zybki",
                            LogoUrl = "/Img/iTechArt.jpg",
                            Experience = "Working for iTechArt 1.4 years."
                        },
                        new Author()
                        {
                            FullName = "Vasia Pupkin",
                            LogoUrl = "/Img/itransition.jpg",
                            Experience = "Working for iTransition 2.2 years."
                        },
                    });
                    context.SaveChanges();
                }

                if (!context.Courses.Any())
                {
                    context.Courses.AddRange(new List<Course>()
                    {
                        new Course()
                        {
                            Name = "\"C# professional\" for the best one!",
                            LogoUrl = "/Img/EPAM.jpg",
                            Description = "Learn best practices.",
                            Price = 300.50M,
                            CompanyId = 1,
                            AuthorId = 1,
                            StartDate = DateTime.Now.AddDays(3),
                            EndDate = DateTime.Now.AddDays(12),
                            CourseCategory = CourseCategory.CSharp
                        },
                        new Course()
                        {

                            Name = "\"C essential!\"",
                            LogoUrl = "/Img/ISsoft.jpg",
                            Description = "Learn good practices.",
                            Price = 75.25M,
                            CompanyId = 2,
                            AuthorId = 2,
                            StartDate = DateTime.Now.AddDays(0),
                            EndDate = DateTime.Now.AddDays(12),
                            CourseCategory = CourseCategory.C
                        },
                        new Course()
                        {
                            Name = "\"C++ master!\"",
                            LogoUrl = "/Img/WG.jpg",
                            Description = "Learn in a proper way.",
                            Price = 100.25M,
                            CompanyId = 3,
                            AuthorId = 3,
                            StartDate = DateTime.Now.AddDays(1),
                            EndDate = DateTime.Now.AddDays(14),
                            CourseCategory = CourseCategory.CPlusPlus
                        },
                        new Course()
                        {
                            Name = "\"PhP start!\"",
                            LogoUrl = "/Img/iTechArt.jpg",
                            Description = "Learn almost somehow.",
                            Price = 14.75M,
                            CompanyId = 4,
                            AuthorId = 4,
                            StartDate = DateTime.Now.AddDays(-5),
                            EndDate = DateTime.Now.AddDays(10),
                            CourseCategory = CourseCategory.PhP
                        },
                        new Course()
                        {
                            Name = "\"Java start for stupid one!\"",
                            LogoUrl = "/Img/itransition.jpg",
                            Description = "Learn somehow.",
                            Price = 10.75M,
                            CompanyId = 5,
                            AuthorId = 5,
                            StartDate = DateTime.Now.AddDays(3),
                            EndDate = DateTime.Now.AddDays(17),
                            CourseCategory = CourseCategory.Java
                        },
                    });
                    context.SaveChanges();
                }

                if (!context.Teachers_Courses.Any())
                {
                    context.Teachers_Courses.AddRange(new List<Teacher_Course>()
                    {
                        new Teacher_Course()
                        {
                            CourseId = 1,
                            TeatherId = 1
                        },
                        new Teacher_Course()
                        {
                            CourseId = 1,
                            TeatherId = 7
                        },
                        new Teacher_Course()
                        {
                            CourseId = 2,
                            TeatherId = 2
                        },
                        new Teacher_Course()
                        {
                            CourseId = 2,
                            TeatherId = 5
                        },
                        new Teacher_Course()
                        {
                            CourseId = 3,
                            TeatherId = 3
                        },
                        new Teacher_Course()
                        {
                            CourseId = 3,
                            TeatherId = 6
                        },
                        new Teacher_Course()
                        {
                            CourseId = 4,
                            TeatherId = 4
                        },
                        new Teacher_Course()
                        {
                            CourseId = 4,
                            TeatherId = 10
                        },
                        new Teacher_Course()
                        {
                            CourseId = 5,
                            TeatherId = 5
                        },
                        new Teacher_Course()
                        {
                            CourseId = 5,
                            TeatherId = 8
                        },
                                               
                    });
                    context.SaveChanges();
                }
            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                string adminUserEmail = "admin@tutorials.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new AppUser()
                    {
                        FullName = "Valerus Znakus",
                        UserName = "adminushka",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "License1!");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "user@tutorials.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new AppUser()
                    {
                        FullName = "Zxkus Ktokus",
                        UserName = "userushka",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "License1!");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
