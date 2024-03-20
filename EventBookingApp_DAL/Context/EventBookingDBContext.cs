using EventBookingApp_DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EventBookingApp_DAL.Context
{
    public class EventBookingDBContext : IdentityDbContext<User>
    {
        public EventBookingDBContext(DbContextOptions<EventBookingDBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());

           
            modelBuilder.Entity<Wallet>()
                .HasOne(w => w.Customer)
                .WithOne(c => c.Wallet)
                .HasForeignKey<Wallet>(w => w.CustomerId);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Customer)
                .WithMany(c => c.Bookings)
                .HasForeignKey(b => b.CustomerId);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Event)
                .WithMany(e => e.Bookings)
                .HasForeignKey(b => b.EventId);
        }

        // DbSets for your entities
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}
