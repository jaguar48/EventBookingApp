using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBookingApp_DAL.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; init; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? UserId { get; set; }
        public User User { get; set; }

        
        public Wallet Wallet { get; set; }
        public ICollection<Booking> Bookings { get; set; } 
    }
}
