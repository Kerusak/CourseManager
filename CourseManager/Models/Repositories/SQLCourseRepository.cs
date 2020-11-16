using CourseManager.Models.Courses;
using CourseManager.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace CourseManager.Models.Repositories
{
    public class SQLCourseRepository : ICourseRepository
    {
        private readonly CourseDBContext context;

        public SQLCourseRepository(CourseDBContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public CourseModel CreateCourse(CourseModel course)
        {
            if (course == null)
            {
                throw new ArgumentNullException(nameof(course));
            }

            context.Courses.Add(course);
            context.SaveChanges();
            return course;
        }

        public CourseModel Delete(int courseId)
        {
            if (courseId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(courseId));
            }

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
            if (courseId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(courseId));
            }

            return context.Courses.Find(courseId);
        }

        public CourseModel Update(CourseModel courseChanges)
        {
            if (courseChanges == null)
            {
                throw new ArgumentNullException(nameof(courseChanges));
            }

            var course = context.Courses.Attach(courseChanges);
            course.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return courseChanges;
        }
    }
}
