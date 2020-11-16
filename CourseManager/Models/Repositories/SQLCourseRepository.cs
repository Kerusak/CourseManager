using CourseManager.Models.Courses;
using CourseManager.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CourseManager.Models.Repositories
{
    public class SQLCourseRepository : ICourseRepository
    {
        private readonly CourseDBContext context;

        public SQLCourseRepository(CourseDBContext context)
        {
            this.context = context;
        }
        public CourseModel CreateCourse(CourseModel course)
        {
            context.Courses.Add(course);
            context.SaveChanges();
            return course;
        }

        public CourseModel Delete(int courseId)
        {
            CourseModel course = context.Courses.Find(courseId);

            if (course != null)
            {
                context.Courses.Remove(course);
                context.SaveChanges();
            }

            return course;
        }

        public IEnumerable<CourseModel> GetAllCourses()
        {
            return context.Courses.Include(course => course.User);
        }

        public CourseModel GetCourse(int courseId)
        {
            return context.Courses.Find(courseId);
        }

        public CourseModel Update(CourseModel courseChanges)
        {
            var course = context.Courses.Attach(courseChanges);
            course.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return courseChanges;
        }
    }
}
