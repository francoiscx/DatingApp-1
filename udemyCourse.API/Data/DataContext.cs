using Microsoft.EntityFrameworkCore;
using udemyCourse.API.Models;

namespace udemyCourse.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options){}

        public DbSet<value> Values { get; set; }
    }
}