using DAL.Models;

namespace BLL.DTOs
{
    public class UserPasswordDTO
    {
        public string Password { get; set; }

        public static explicit operator User(UserPasswordDTO dto)
        {
            if (dto == null)
                return null;

            return new User
            {
                Password = dto.Password
            };
        }

        public static implicit operator UserPasswordDTO(User user)
        {
            if (user == null)
                return null;

            return new UserPasswordDTO
            {
                Password = user.Password
            };
        }
    }
}
