using Gamestorev3.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Gamestore.Models
{
    public class StoreDbContext:DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options):base(options)
        {
        }
       public DbSet<Users> Users { get; set; }
       public DbSet<Games> Games { get; set; }
       public DbSet<UserPhotos> Photos { get; set; }
       public DbSet<Orders> Orders { get; set; }
       public DbSet<OrderDetails> OrderDetails { get; set; }
       public DbSet<Publisher> Publisher { get; set; }
       public DbSet<Admins> Admins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetails>().HasKey(s => new
            {
                s.OrderId,
                s.GameId

            });
            modelBuilder.Entity<OrderDetails>()
        .HasOne(od => od.Orders)
        .WithMany(o => o.Details)
        .HasForeignKey(od => od.OrderId)
        .OnDelete(DeleteBehavior.Restrict);
            base.OnModelCreating(modelBuilder);
        }
    }
}
