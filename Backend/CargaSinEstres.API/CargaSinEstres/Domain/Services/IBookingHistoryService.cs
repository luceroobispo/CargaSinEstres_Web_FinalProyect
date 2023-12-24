using CargaSinEstres.API.CargaSinEstres.Domain.Models;
using CargaSinEstres.API.CargaSinEstres.Domain.Services.Communication;
using CargaSinEstres.API.CargaSinEstres.Resources;

namespace CargaSinEstres.API.CargaSinEstres.Domain.Services;

/// <summary>
/// Represents a service for managing booking history entities.
/// </summary>
///<remarks> Grupo 1: Carga sin estres </remarks>
public interface IBookingHistoryService{
    /// <summary>
    /// Gets a booking history entity asynchronously by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the booking history entity.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the booking history entity.</returns>
    Task<BookingHistory> GetBookingAsync(int id);

    /// <summary>
    /// Gets a list of all booking history entities asynchronously.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of booking history entities.</returns>
    Task<IEnumerable<BookingHistory>> GetBookingHistoryAsync();

    /// <summary>
    /// Gets a list of booking history entities asynchronously filtered by client identifier.
    /// </summary>
    /// <param name="clientId">The identifier of the client.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of booking history entities.</returns>
    Task<IEnumerable<BookingHistory>> GetBookingsByClientIdAsync(int clientId);

    /// <summary>
    /// Gets a list of booking history entities asynchronously filtered by company identifier.
    /// </summary>
    /// <param name="companyId">The identifier of the company.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of booking history entities.</returns>
    Task<IEnumerable<BookingHistory>> GetBookingsByCompanyIdAsync(int companyId);

    /// <summary>
    /// Creates a new booking history entity asynchronously.
    /// </summary>
    /// <param name="booking">The booking history entity to be created.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a response with the created booking history entity.</returns>
    Task<BookingHistoryResponse> CreateBookingAsync(BookingHistory booking);

    /// <summary>
    /// Updates an existing booking history entity asynchronously.
    /// </summary>
    /// <param name="id">The unique identifier of the booking history entity to be updated.</param>
    /// <param name="booking">The updated booking history entity.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a response with the updated booking history entity.</returns>
    Task<BookingHistoryResponse> UpdateBookingAsync(int id, UpdateBookingHistoryResource booking);
}
