using org_empleados.Domain.DTOs.Users;
using org_empleados.Domain.Models;

namespace org_empleados.Mappers
{
    public static class UserMappers
    {
        public static User CreateUserFromDTO(CreateUserDTO userDTO)
        {
            return new User { UserName = userDTO.UserName, Password = userDTO.Password, FkIdRole = userDTO.IdRole };
        }

        public static User UpdateUserFromDTO(UpdateUserDTO userDTO)
        {
            return new User { UserName = userDTO.UserName, Password = userDTO.Password, FkIdRole = userDTO.IdRole };
        }
        public static User LoginUserFromDTO(LoginUserDTO userDTO)
        {
            return new User { UserName = userDTO.UserName, Password = userDTO.Password };
        }
    }
}
