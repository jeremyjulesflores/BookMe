using AutoMapper;
using BookMe.API.Auth.Models.Booking;
using BookMe.API.Auth.Services.Interfaces;
using BookMe.API.Auth.Services.Service;
using Microsoft.EntityFrameworkCore;

namespace BookMe.API.Auth.Services.Booking
{
    public class BookingService : IBookingService
    {
        private readonly IMapper _mapper;
        private readonly IServiceService _serviceService;
        private readonly ApplicationContext _applicationContext;

        public BookingService(IMapper mapper, IServiceService serviceService, ApplicationContext applicationContext)
        {
            _mapper = mapper;
            _serviceService = serviceService;
            _applicationContext = applicationContext;

        }

        public async Task<Entities.Booking> CreateAsync(Guid serviceId, BookingCreationViewModel bookingCreation)
        {
            var service =await _serviceService.GetAsync(serviceId);

            if(service == null)
            {
                throw new Exception();
            }

            var booking = _mapper.Map<Entities.Booking>(bookingCreation);

            if(booking == null)
            {
                throw new Exception();
            }

            service.Bookings.Add(booking);

            if(_applicationContext.SaveChanges()== 0)
            {
                throw new Exception();
            }

            return booking;
        }

        public async Task<IEnumerable<Entities.Booking>> ListAsync(Guid serviceId)
        {
            var service = await _applicationContext.Service
                .Include(s => s.Bookings)
                .FirstOrDefaultAsync(s => s.ServiceId == serviceId);

            if(service == null)
            {
                throw new Exception();
            }
            return service.Bookings;
        }
    }
}
