using CourseManager.Models.Courses;
using CourseManager.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace CourseManager.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // for test without user
            modelBuilder.Entity<CourseModel>().HasData(
                new CourseModel()
                {
                    CourseID = 1,
                    Title = ".NET Course for beginners",
                    Description = "Improve your skills",
                    Price = 250,
                    TimeStart = CourseTime.Ten,
                    TimeEnd = CourseTime.Twelve,
                    DateStart = CourseDate.Thursday
                },
                new CourseModel()
                {
                    CourseID = 2,
                    Title = "Xamarin presentation",
                    Description = "Come everyone",
                    Price = 0,
                    TimeStart = CourseTime.Fourteen,
                    TimeEnd = CourseTime.Fifteen,
                    DateStart = CourseDate.Monday
                }
                );
        }
    }
}
