using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using udemyCourse.API.Models;

namespace udemyCourse.API.Data
{
    public class Seed
    {
        public static void SeedUsers(DataContext context)
        // check if there are users in the Database
        {
            if (!context.Users.Any())
            {
                var userData = System.IO.File.ReadAllText("Data/UserSeedData.json");
                // convert data in variable userData to objects to loop through
                var users = JsonConvert.DeserializeObject<List<User>>(userData);
                // loop through each user
                foreach(var user in users)
                {
                    byte[] passwordhash, passwordsalt;
                    CreatePasswordHash("password",
                                       out passwordhash,
                                       out passwordsalt);
                // Add password hash and salt to user objects
                                        user.PasswordHash = passwordhash;
                                        user.PasswordSalt = passwordsalt;
                // Change username to lowercase
                                        user.Username = user.Username.ToLower();
                                        // add user objects to context
                                        context.Users.Add(user);
                }
                // save changes 
                context.SaveChanges();
            }
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt =  hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
            
        }
    }
}