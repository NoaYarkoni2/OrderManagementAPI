using Microsoft.EntityFrameworkCore;
using OrderManagementAPI.Models;

namespace OrderManagementAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
        {
        }

        public DbSet<Session> Sessions { get; set; }
        public DbSet<Wapp> Wapp { get; set; }
        public DbSet<Scripts> Script { get; set; }
    }
}
