using Microsoft.EntityFrameworkCore;
using UserRepository.Models;

namespace UserRepository.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Post> Post { get; set; }

    }
}