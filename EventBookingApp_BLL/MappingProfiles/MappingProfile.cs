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
            CreateMap<Event, GetEventResponse>();
            CreateMap<UpdateEventRequest, Event>();
            CreateMap<Booking, BookingResponse>()
                .ForMember(dest => dest.BookingId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId))
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.UserName ))
                .ForMember(dest => dest.CustomerEmail, opt => opt.MapFrom(src => src.Customer.Email))
                .ForMember(dest => dest.CustomerPhoneNumber, opt => opt.MapFrom(src => src.Customer.PhoneNumber))
                .ForMember(dest => dest.EventId, opt => opt.MapFrom(src => src.EventId))
                .ForMember(dest => dest.EventTitle, opt => opt.MapFrom(src => src.Event.Title))
                .ForMember(dest => dest.EventDescription, opt => opt.MapFrom(src => src.Event.Description))
                .ForMember(dest => dest.EventDate , opt => opt.MapFrom(src => src.Event.EventDate ))
                
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Event.Location ))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Event.Price))
                .ForMember(dest => dest.AmountPaid, opt => opt.MapFrom(src => src.AmountPaid))
                .ForMember(dest => dest.NoOfTicket, opt => opt.MapFrom(src => src.NoOfTicket))
                .ForMember(dest => dest.BookingDate, opt => opt.MapFrom(src => src.BookingDate))
                .ForMember(dest => dest.IsPaid, opt => opt.MapFrom(src => src.IsPaid))
                .ForMember(dest => dest.IsCancelled, opt => opt.MapFrom(src => src.IsCancelled));
        }
    }

}
