using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarWash.Models.DataModels
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }

        public static User AddNew(string username, string password, bool persist = true)
        {
            StringBuilder sb = new StringBuilder();
            Database.CarWashContext context = new Database.CarWashContext();
            byte[] salt = GenerateRandomNumber(32);
            string salt_string = String.Concat(salt.Select(item => item.ToString("x2")));
            byte[] pass = HashPassword(Encoding.Unicode.GetBytes(password), salt, 50000);
            foreach (byte item in pass)
            {
                sb.Append(item.ToString("x2"));
            }

            User user = new User { Username = username, Password = sb.ToString(), Salt = salt_string };
            if (persist)
            {
                context.Users.Add(user);
            }
            return user;
        }

        public static byte[] HashPassword(byte[] toBeHashed, byte[] salt, int numberOfRounds)
        {
            using (var rfc2898 = new Rfc2898DeriveBytes(toBeHashed, salt, numberOfRounds))
            {
                return rfc2898.GetBytes(32);
            }
        }

        public static byte[] GenerateRandomNumber(int length)
        {
            using (var randomNumberGenerator = new RNGCryptoServiceProvider())
            {
                var randomNumber = new byte[length];
                randomNumberGenerator.GetBytes(randomNumber);
                return randomNumber;
            }
        }
    }
}
