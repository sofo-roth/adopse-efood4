using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNet.Identity;

namespace Domain.AccountManager
{
    internal class PasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            return DoHashProcess(password);
        }

        public PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
            var pwd = RetrieveHash(hashedPassword, providedPassword);

            return hashedPassword.Equals(pwd) ? PasswordVerificationResult.Success : PasswordVerificationResult.Failed;
        }

        private static string CreateSalt()
        {
            var rng = new RNGCryptoServiceProvider();
            var buff = new byte[10];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }

        private string DoHashProcess(string pwd)
        {
            var salt = CreateSalt();
            var hashedPassword = GenerateHash(pwd, salt);
            var finalPassword = salt + hashedPassword;

            return finalPassword;
        }

        private string RetrieveHash(string dbPassword, string providedPassword)
        {
            try
            {
                var salt = dbPassword.Substring(0, 16);

                var finalPassword = GenerateHash(providedPassword, salt);

                return salt + finalPassword;
            }
            catch (ArgumentOutOfRangeException)
            {
                return string.Empty;
            }
        }

        private string GenerateHash(string pwd, string salt)
        {
            var bytes = Encoding.UTF8.GetBytes(pwd + salt);
            var sha256HashString = new SHA256Managed();
            var hash = sha256HashString.ComputeHash(bytes);

            return Convert.ToBase64String(hash);
        }
    }
}
