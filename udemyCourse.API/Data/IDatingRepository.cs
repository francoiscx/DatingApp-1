using System.Collections.Generic;
using System.Threading.Tasks;
using udemyCourse.API.Models;

namespace udemyCourse.API.Data
{
    public interface IDatingRepository
    {
        // Generic code for adding a type of user or photos
        void Add<T>(T entity) where T: class;
        // Generic code for deleting
        void Delete<T>(T entity) where T: class;
        // Code to save items to database
        Task<bool> SaveAll();
        // Get a list of users
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int id);

    }
}