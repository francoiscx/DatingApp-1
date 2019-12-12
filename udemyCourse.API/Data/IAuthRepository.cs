using System.Threading.Tasks;
using udemyCourse.API.Models;

namespace udemyCourse.API.Data
{
    public interface IAuthRepository
    {
         Task<User> Register(User user, string password);
         Task <User> Loggin(string username, string password);
         Task<bool> UserExists(string username);
    }
}