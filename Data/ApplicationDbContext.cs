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

        public DbSet<Session> sessions { get; set; }
        public DbSet<Wapp> wapp { get; set; }
        public DbSet<Scripts> scripts { get; set; }
    }
}
