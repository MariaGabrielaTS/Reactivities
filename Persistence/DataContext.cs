using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    //DbContext instance represents a session with the database and can be used to query and save instances of your entities.
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        
        public DbSet<Activity> Activities { get; set; }
    }
}