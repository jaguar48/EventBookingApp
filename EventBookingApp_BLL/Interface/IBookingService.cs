using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBookingApp_BLL.Interface
{
    
     public interface IBookingService
    {
        Task<string> BookEventAsync(int eventId, int numberOfTickets);
      
        Task<string> CancelBookingAsync(int bookingId);
        /*Task<string> CancelBookingAsync(int bookingId);*/
    }
}
