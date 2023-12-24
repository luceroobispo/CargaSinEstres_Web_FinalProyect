using CargaSinEstres.API.CargaSinEstres.Domain.Models;

namespace CargaSinEstres.API.CargaSinEstres.Domain.Repositories;
/// <summary>
/// Represents a repository for managing booking history entities.
/// </summary>
///<remarks> Grupo 1: Carga sin estres </remarks>
public interface IBookingHistoryRepository {
    /// <summary>
    /// Gets a booking history entity asynchronously by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the booking history entity.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the booking history entity.</returns>
    Task<BookingHistory> GetAsync(int id);

     /// <summary>
    /// Gets a list of all booking history entities asynchronously.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of booking history entities.</returns>
    Task<IEnumerable<BookingHistory>> ListAsync();

    /// <summary>
    /// Gets a list of booking history entities asynchronously filtered by client identifier.
    /// </summary>
    /// <param name="clientId">The identifier of the client.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of booking history entities.</returns>
    Task<IEnumerable<BookingHistory>> ListByClientIdAsync(int clientId);

    /// <summary>
    /// Gets a list of booking history entities asynchronously filtered by company identifier.
    /// </summary>
    /// <param name="companyId">The identifier of the company.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of booking history entities.</returns> 
    Task<IEnumerable<BookingHistory>> ListByCompanyIdAsync(int clientId);

    /// <summary>
    /// Adds a new booking history entity asynchronously.
    /// </summary>
    /// <param name="booking">The booking history entity to be added.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task AddAsync(BookingHistory booking);

    /// <summary>
    /// Updates an existing booking history entity asynchronously.
    /// </summary>
    /// <param name="booking">The booking history entity to be updated.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task UpdateAsync(BookingHistory booking);

    /// <summary>
    /// Removes a booking history entity asynchronously.
    /// </summary>
    /// <param name="booking">The booking history entity to be removed.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task RemoveAsync(BookingHistory booking);
}
