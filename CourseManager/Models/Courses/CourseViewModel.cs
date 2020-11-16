using CourseManager.Models.Enums;
using CourseManager.Models.User;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourseManager.Models.Courses
{
    public class CourseViewModel
    {
        public int CourseID { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public UserModel User { get; set; }
        [Required(ErrorMessage = "Укажите время начала курса")]
        [Display(Name = "Время начала курса: ")]
        public CourseTime TimeStart { get; set; }
        [Required(ErrorMessage = "Укажите время конца курса")]
        [Display(Name = "Время конца курса: ")]
        public CourseTime TimeEnd { get; set; }
        [Required(ErrorMessage = "Укажите день недели")]
        [Display(Name = "День недели: ")]
        public CourseDate DateStart { get; set; }
        public List<CourseModel> Courses { get; set; }
    }
}
