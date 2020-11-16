using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CourseManager.Models.Enums
{
    public enum CourseTime
    {
        [Display(Name = "9:00")]
        [Description("9:00")]
        Nine = 1,
        [Display(Name = "10:00")]
        [Description("10:00")]
        Ten,
        [Display(Name = "11:00")]
        [Description("11:00")]
        Eleven,
        [Display(Name = "12:00")]
        [Description("12:00")]
        Twelve,
        [Display(Name = "13:00")]
        [Description("13:00")]
        Thirteen,
        [Display(Name = "14:00")]
        [Description("14:00")]
        Fourteen,
        [Display(Name = "15:00")]
        [Description("15:00")]
        Fifteen,
        [Display(Name = "16:00")]
        [Description("16:00")]
        Sixteen,
        [Display(Name = "17:00")]
        [Description("17:00")]
        Seventeen
    }
}