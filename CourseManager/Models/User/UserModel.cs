using Microsoft.AspNetCore.Identity;

namespace CourseManager.Models.User
{
    public class UserModel : IdentityUser
    {
        public bool isAdmin { get; set; }
    }
}
