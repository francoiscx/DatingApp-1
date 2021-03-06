using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using udemyCourse.API.Models;

namespace udemyCourse.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        public AuthRepository(DataContext context)
        {
            _context = context;

        }
        public async Task<User> Loggin(string username, string password)
        {
            var user = await _context.Users.Include(p => p.Photos).FirstOrDefaultAsync(x => x.Username == username);

            if (user == null)
            return null;

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            return null;

            return user;
        }
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
        using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHAsh = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for( int i = 0; i< computedHAsh.Length; i++)
                {
                    if(computedHAsh[i] != passwordHash[i]) return false;
                }
            }
            return true;
        }

        public async Task<User> Register(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }
// create password hash
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt =  hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
            
        }

        public async Task<bool> UserExists(string username)
        {
            if (await _context.Users.AnyAsync(x => x.Username == username))
            return true;

            return false;
        }
    }
}