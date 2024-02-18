using BookMe.API.Auth.Models.Booking;

namespace BookMe.API.Auth.Services.Booking
{
    public interface IBookingService
    {
        /// <summary>
        /// Get all bookings
        /// </summary>
        /// <param name="serviceId">Id of service</param>
        /// <returns>List of bookings for the service</returns>
        public Task<IEnumerable<Entities.Booking>> ListAsync(Guid serviceId);
        /// <summary>
        /// Create booking
        /// </summary>
        /// <param name="serviceId">Id of service</param>
        /// <returns>Created booking</returns>
        public Task<Entities.Booking> CreateAsync(Guid serviceId, BookingCreationViewModel bookingCreation);
    }
}
