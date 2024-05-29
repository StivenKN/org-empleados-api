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

        public static bool ComparePassword(string password, string hashPassword)
        {
            ArgumentNullException.ThrowIfNull(password, "It is needed a password");
            ArgumentNullException.ThrowIfNull(hashPassword, "It is needed a hash password");
            return BCrypt.Net.BCrypt.Verify(password, hashPassword);
        }
    }
}
