using DAL.Models;

namespace BLL.DTOs
{
    public class NewUserDTO
    {
        /*public int UserId { get; set; }*/
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

        public static explicit operator User(NewUserDTO dto)
        {
            if (dto == null)
                return null;

            return new User
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                UserName = dto.UserName,
                Password = dto.Password,
                IsAdmin = dto.IsAdmin
            };
        }

        public static implicit operator NewUserDTO(User user)
        {
            if (user == null)
                return null;

            return new NewUserDTO
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Password = user.Password,
                IsAdmin = user.IsAdmin
            };
        }
    }
}
