using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBookingApp_DAL.Entities
{
    public class Booking
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int EventId { get; set; }
        public Event Event { get; set; }

        public DateTime BookingDate { get; set; }
        public bool IsPaid { get; set; }
        public decimal AmountPaid { get; set; }
        public int NoOfTicket { get; set; } 
        public bool IsCancelled { get; set; }

    }

}
