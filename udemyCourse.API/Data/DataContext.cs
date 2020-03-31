
using udemyCourse.API.Models;
using Microsoft.EntityFrameworkCore;


namespace udemyCourse.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options){}
// setting databse with tables
        public DbSet<value> Values { get; set; }
       public DbSet<User> Users { get; set; }
       public DbSet <Photo> photos { get; set; }
    }
}