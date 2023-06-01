using BLL.DTOs;
using DAL.Models;

namespace BLL.Services
{
    public interface IUserService
    {
        public string Authenticate(string username, string password);
        public string Register(NewUserDTO user);
        /*public void UpdateUser(int userId, UserPasswordDTO userdto);*/
        public User GetUserById(int id);
    }
}
