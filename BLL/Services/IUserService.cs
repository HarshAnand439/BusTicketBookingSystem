using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IUserService
    {
        public Task<string> Authenticate(string username, string password);
        public Task Register(User user);
        public Task UpdateUser(int userId, User user);
        public Task<User> GetUserById(int id);
    }
}
