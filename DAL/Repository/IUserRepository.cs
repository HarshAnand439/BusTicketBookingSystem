using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IUserRepository
    {
        public Task<User> GetUserById(int userId);
        public Task<User> GetUserByUsername(string username);
        public Task CreateUser(User user);
        public Task UpdateUser(User user);
    }
}
