using EventBookingApp_DAL.Dtos.Request;
using EventBookingApp_DAL.Dtos.Response;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBookingApp_BLL.Interface
{
    public interface IEventService
    {
        Task<string> CreateEventAsync(CreateEventRequest eventRequest);
       Task<GetEventResponse > GetEventByIdAsync(int eventId);
        Task<string> UpdateEventAsync(int eventId, UpdateEventRequest eventRequest);

        
       Task<string> DeleteEventAsync(int eventId);
    }
}
