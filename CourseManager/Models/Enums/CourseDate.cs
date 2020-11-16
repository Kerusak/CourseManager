using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CourseManager.Models.Enums
{
    public enum CourseDate
    {
        [Display(Name = "Понедельник")]
        [Description("Понедельник")]
        Monday = 1,
        [Display(Name = "Вторник")]
        [Description("Вторник")]
        Tuesday,
        [Display(Name = "Среда")]
        [Description("Среда")]
        Wednesday,
        [Display(Name = "Четверг")]
        [Description("Четверг")]
        Thursday,
        [Display(Name = "Пятница")]
        [Description("Пятница")]
        Friday
    }
}