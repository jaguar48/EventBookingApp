using EventBookingApp_BLL.Interface;
using EventBookingApp_Contracts;
using EventBookingApp_DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EventBookingApp_BLL.Implementation
{

    public class BookingService : IBookingService
    {
        private readonly IRepository<Booking> _bookingRepo;
        private readonly IRepository<Wallet> _walletRepo;
        private readonly IRepository<Event> _eventRepo;
        private readonly IRepository<Customer> _customerRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BookingService(IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _unitOfWork = unitOfWork;
            _bookingRepo = _unitOfWork.GetRepository<Booking>();
            _customerRepo = _unitOfWork.GetRepository<Customer>();
            _eventRepo = _unitOfWork.GetRepository<Event>();
            _walletRepo = _unitOfWork.GetRepository<Wallet>();
        }

        public async Task<string> BookEventAsync(int eventId)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                throw new Exception("User not found");
            }

            Customer customer = await _customerRepo.GetSingleByAsync(x => x.UserId == userId, include: x => x.Include(x => x.Wallet));


            var eventEntity = await _eventRepo.GetByIdAsync(eventId);


            if (eventEntity == null || customer == null)
            {
                throw new Exception("Event or customer not found");
            }


            var wallet = customer.Wallet;
            if (wallet.Balance < eventEntity.Price)
            {
                return "Insufficient funds in wallet";
            }


            var booking = new Booking
            {
                CustomerId = customer.Id,
                EventId = eventId,
                BookingDate = DateTime.Now,
                IsPaid = true,
                AmountPaid = eventEntity.Price
            };


            wallet.Balance -= eventEntity.Price;

            try
            {

                await _walletRepo.UpdateAsync(wallet);
                await _bookingRepo.AddAsync(booking);
                await _unitOfWork.SaveChangesAsync();

                return "Event booked successfully";
            }
            catch (Exception ex)
            {

                return $"An error occurred: {ex.Message}";
            }
        }

        public async Task<string> CancelBookingAsync(int bookingId)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                throw new Exception("User not found");
            }

            // Retrieve the booking entity including the Customer navigation property
            var booking = await _bookingRepo.GetSingleByAsync(
                b => b.Id == bookingId,
                include: b => b.Include(b => b.Customer).ThenInclude(c => c.Wallet));

            if (booking == null)
            {
                return "Booking not found";
            }

            // Ensure that the booking has a customer associated with it
            if (booking.Customer == null)
            {
                return "Customer not found for the booking";
            }

            // Check if the logged-in user is authorized to cancel the booking
            if (booking.Customer.UserId != userId)
            {
                return "Unauthorized: You do not have permission to cancel this booking";
            }

            // Check if the booking is already canceled
            if (booking.IsCancelled)
            {
                return "Booking is already canceled";
            }

            // Mark the booking as canceled
            booking.IsCancelled = true;

            // If the booking is paid, refund the amount to the customer's wallet
            if (booking.IsPaid)
            {
                // Ensure that the booking's customer has a wallet associated with it
                if (booking.Customer.Wallet == null)
                {
                    return "Wallet not found for the customer";
                }

                // Retrieve the event associated with the booking
                var eventEntity = await _eventRepo.GetByIdAsync(booking.EventId);
                if (eventEntity == null)
                {
                    return "Event not found";
                }

                // Refund the amount to the customer's wallet
                booking.Customer.Wallet.Balance += eventEntity.Price;

                // Update the wallet
                await _walletRepo.UpdateAsync(booking.Customer.Wallet);
            }

            try
            {
                // Save changes to the database
                await _unitOfWork.SaveChangesAsync();
                return "Booking canceled successfully";
            }
            catch (Exception ex)
            {
                return $"An error occurred while canceling the booking: {ex.Message}";
            }
        }


    }
}
