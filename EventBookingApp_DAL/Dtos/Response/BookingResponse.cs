using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBookingApp_DAL.Dtos.Response
{
    
        public class BookingResponse
        {
            public int BookingId { get; set; }
            public int CustomerId { get; set; }
            public string CustomerName { get; set; }
            public string CustomerEmail { get; set; }
            public string CustomerPhoneNumber { get; set; }
            public int EventId { get; set; }
            public string EventTitle { get; set; }
            public string EventDescription { get; set; }
            public DateTime EventStartDate { get; set; }
            public DateTime EventEndDate { get; set; }
            public string Location { get; set; }
            public decimal Price { get; set; }
            public DateTime BookingDate { get; set; }
            public bool IsPaid { get; set; }
            public bool IsCancelled { get; set; }
            // Add more properties as needed
        }

    
}
