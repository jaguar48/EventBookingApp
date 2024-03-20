using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBookingApp_DAL.Dtos.Response
{
    public class GetEventResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime BookingStartDate { get; set; }
        public DateTime BookingEndDate { get; set; }
        public string Location { get; set; }
        public decimal Price { get; set; }
        public DateTime EventDate { get; set; }
    }
}
