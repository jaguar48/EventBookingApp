using AutoMapper;
using EventBookingApp_BLL.Interface;
using EventBookingApp_Contracts;
using EventBookingApp_DAL.Dtos.Request;
using EventBookingApp_DAL.Dtos.Response;
using EventBookingApp_DAL.Entities;

namespace EventBookingApp_BLL.Implementation
{
    public class EventService : IEventService
    {
        private readonly IRepository<Event> _eventRepo;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IRepository<Wallet> _walletRepo;
        private readonly IMapper _mapper;

        public EventService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            /*_logger = logger;*/
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _eventRepo = _unitOfWork.GetRepository<Event>();
            _walletRepo = _unitOfWork.GetRepository<Wallet>();
        }

        public async Task<string> CreateEventAsync(CreateEventRequest eventRequest)
        {
            var newEvent = _mapper.Map<Event>(eventRequest);
            await _eventRepo.AddAsync(newEvent);
            await _unitOfWork.SaveChangesAsync();
            return "Event created successfully";
        }

        public async Task<GetEventResponse> GetEventByIdAsync(int eventId)
        {
            var existingEvent = await _eventRepo.GetByIdAsync(eventId);
            if (existingEvent == null)
            {
                throw new Exception("Event not found");
            }
            var eventDTO = _mapper.Map<GetEventResponse>(existingEvent);
            return eventDTO;
        }
        public async Task<string> UpdateEventAsync(int eventId, UpdateEventRequest eventRequest)
        {
            var existingEvent = await _eventRepo.GetByIdAsync(eventId);
            if (existingEvent == null)
            {
                throw new Exception("Event not found");
            }
            _mapper.Map(eventRequest, existingEvent);
            await _eventRepo.UpdateAsync(existingEvent);
            await _unitOfWork.SaveChangesAsync();
            return "Event updated successfully";
        }
        public async Task<string> DeleteEventAsync(int eventId)
        {
            var existingEvent = await _eventRepo.GetByIdAsync(eventId);
            if (existingEvent == null)
            {
                throw new Exception("Event not found");
            }
            await _eventRepo.DeleteAsync(existingEvent);
            await _unitOfWork.SaveChangesAsync();
            return "Event deleted successfully";
        }
    }
}


