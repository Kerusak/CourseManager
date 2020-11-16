using CourseManager.Models.Courses;
using System.Collections.Generic;

namespace CourseManager.Models.Interfaces
{
    public interface ICourseRepository
    {
        CourseModel GetCourse(int courseId);
        IEnumerable<CourseModel> GetAllCourses();
        CourseModel CreateCourse(CourseModel course);
        CourseModel Update(CourseModel courseChanges);
        CourseModel Delete(int courseId);
    }
}
