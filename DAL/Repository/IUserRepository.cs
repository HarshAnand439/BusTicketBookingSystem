using DAL.Models;

namespace DAL.Repository
{
    public interface IUserRepository
    {
        public User GetUserById(int userId);
        public User GetUserByUsername(string username);
        public string CreateUser(User user);
        /*public void UpdateUser(User user);*/
    }
}
