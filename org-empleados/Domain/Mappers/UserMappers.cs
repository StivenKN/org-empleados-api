using org_empleados.Domain.DTOs.Users;
using org_empleados.Domain.Models;

namespace org_empleados.Mappers
{
    public static class UserMappers
    {
        public static User ToModelFromCreateDTO(this CreateUserDTO userDTO)
        {
            return new User { UserName = userDTO.UserName, PasswordHash = userDTO.Password, FkIdRole = userDTO.IdRole };
        }

        public static User ToModelFromUpdateDTO(this UpdateUserDTO userDTO)
        {
            return new User { UserName = userDTO.UserName, PasswordHash = userDTO.Password, FkIdRole = userDTO.IdRole };
        }
        public static User ToModelFromLoginDTO(this LoginUserDTO userDTO)
        {
            return new User { UserName = userDTO.UserName, PasswordHash = userDTO.Password };
        }
    }
}
