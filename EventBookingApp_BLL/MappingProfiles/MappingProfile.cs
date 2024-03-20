using AutoMapper;
using EventBookingApp_DAL.Dtos.Request;
using EventBookingApp_DAL.Dtos.Response;
using EventBookingApp_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBookingApp_BLL.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRegistrationRequest, User>();
            CreateMap<CreateEventRequest, Event>();
            CreateMap<Event, GetEventResponse >();
            CreateMap<UpdateEventRequest , Event>();
        }
    }
}
