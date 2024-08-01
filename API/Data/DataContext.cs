using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext(DbContextOptions options) : DbContext(options)
    {
        //database called Users
        public DbSet<AppUser> Users { get; set; }
    }
}
