using CourseManager.Models.Courses;
using CourseManager.Models.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CourseManager.Models
{
    public class CourseDBContext : IdentityDbContext<UserModel>
    {
        public DbSet<CourseModel> Courses { get; set; }

        public CourseDBContext(DbContextOptions<CourseDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }
    }
}