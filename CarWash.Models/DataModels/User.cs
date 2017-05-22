using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CarWash.Models.Utilities;

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

        /// <summary>
        /// Adds a new user to the database.
        /// </summary>
        /// <returns>The new user instance.</returns>
        /// <param name="username">Username.</param>
        /// <param name="password">Password.</param>
        /// <param name="persist">If set to <c>true</c> persist the created user to the database.</param>
        public static User AddNew(string username, string password, bool persist = true)
        {
            StringBuilder sb = new StringBuilder();
            Database.CarWashContext context = new Database.CarWashContext();
            byte[] salt = Randomizer.GenerateRandomNumber(32);
            string salt_string = String.Concat(salt.Select(item => item.ToString("x2")));
            byte[] pass = Hashing.HashPassword(password, salt, 50000);
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


        /// <summary>
        /// Authenticate using the specified username and password.
        /// </summary>
        /// <returns>If the provided username and password matches.</returns>
        /// <param name="username">Username.</param>
        /// <param name="password">Password.</param>
        public static bool Authenticate(string username, string password)
        {
            Database.CarWashContext context = new Database.CarWashContext();
            User user = context.Users.Where(u => u.Username == username).First();
            if (String.Concat(Hashing.HashPassword(password, user.Salt, 50000).Select(item => item.ToString("x2"))) == user.Password)
            {
                return true;
            }
            return false;
        }
    }
}
