using DAL.Data;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _db;

        public UserRepository(AppDbContext db)
        {
            _db = db;
        }

        public User GetUserById(int userId)
        {
            return _db.Users.Where(x => x.UserId == userId).FirstOrDefault();
        }

        public User GetUserByUsername(string username)
        {
            return _db.Users.Where(x => x.UserName == username).FirstOrDefault();
        }

        public string CreateUser(User user)
        {
            if((_db.Users.Add(user) != null)){
                _db.SaveChanges();
                return user.Token;
            }
            return null;
        }

        /*public void UpdateUser(User user)
        {
            *//*_db.Entry(user).State = EntityState.Modified;*//*
            _db.Users.Update(user);
            _db.SaveChanges();
        }*/
    }
}
