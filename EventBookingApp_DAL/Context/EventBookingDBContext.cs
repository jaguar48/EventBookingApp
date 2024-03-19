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


        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Event> Events { get; set; }
        
    }


}
