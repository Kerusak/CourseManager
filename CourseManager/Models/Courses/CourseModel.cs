using CourseManager.Models.Enums;
using CourseManager.Models.User;
using System.ComponentModel.DataAnnotations;

namespace CourseManager.Models.Courses
{
    public class CourseModel
    {
        [Key]
        public int CourseID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public UserModel User { get; set; }
        public CourseTime TimeStart { get; set; }
        public CourseTime TimeEnd { get; set; }
        public CourseDate DateStart { get; set; }
    }
}