using BCrypt.Net;

namespace org_empleados.Application.Lib
{
    public static class Encryption
    {
        public static string EncryptPassword(string password)
        {
            ArgumentNullException.ThrowIfNull(password, "It is needed a password");
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}
