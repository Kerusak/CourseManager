using CourseManager.Models.User;

namespace CourseManager.Models.Interfaces
{
    public interface IUserRepository
    {
        UserModel GetUser(int userId);
        UserModel GetUser(int userId, string password);
        UserModel CreateUser(UserModel user);
        UserModel UpdateUser(UserModel userChanges);
        UserModel DeleteUser(int userId);
    }
}