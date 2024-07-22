using Microsoft.EntityFrameworkCore;
using Obqvi_API.DB.Models;

namespace Obqvi_API.DB
{
    public class ObqviContext : DbContext
    {
        public ObqviContext(DbContextOptions<ObqviContext> options) : base(options)
        {
                
        }

        public DbSet<User> Users { get; set; }
    }
}
