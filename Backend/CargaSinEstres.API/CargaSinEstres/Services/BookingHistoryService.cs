using CargaSinEstres.API.CargaSinEstres.Domain.Models;
using CargaSinEstres.API.CargaSinEstres.Domain.Repositories;
using CargaSinEstres.API.CargaSinEstres.Domain.Services;
using CargaSinEstres.API.CargaSinEstres.Domain.Services.Communication;
using CargaSinEstres.API.CargaSinEstres.Resources;
namespace CargaSinEstres.API.CargaSinEstres.Services;

/// <summary>
/// Service class for handling booking history operations.
/// </summary>
///<remarks> Grupo 1: Carga sin estres </remarks>
public class BookingHistoryService : IBookingHistoryService
{
    private readonly IBookingHistoryRepository _bookingHistoryRepository;
    private readonly IChatService _chatService;
    private readonly IWorkerService _workerService;

    /// <summary>
    /// Initializes a new instance of the <see cref="BookingHistoryService"/> class.
    /// </summary>
    /// <param name="bookingHistoryRepository">The repository for booking history.</param>
    /// <param name="chatService">The service for chat operations.</param>
    public BookingHistoryService(IBookingHistoryRepository bookingHistoryRepository, IChatService chatService, IWorkerService workerService)
    {
        _bookingHistoryRepository = bookingHistoryRepository;
        _chatService = chatService;
        _workerService = workerService;
    }

    /// <summary>
    /// Retrieves a booking by its identifier, including associated chat data.
    /// </summary>
    /// <param name="id">The identifier of the booking to retrieve.</param>
    /// <returns>The booking with associated chat data.</returns>
    public async Task<BookingHistory> GetBookingAsync(int id)
    {
        var booking = await _bookingHistoryRepository.GetAsync(id);
        if (booking != null)
        {
            booking.Chats = await _chatService.GetChatsAsync(); // Obtener los chats asociados
            var workers = await _workerService.GetWorkersAsync(); // Obtener los trabajadores asociados
            if (workers != null) {
                foreach (var worker in workers)
                {
                    booking.Workers.Add(worker.Id);
                }
            }
        }
        return booking;
    }

    /// <summary>
    /// Retrieves a list of all bookings, including associated chat data.
    /// </summary>
    /// <returns>The list of bookings with associated chat data.</returns>
    public async Task<IEnumerable<BookingHistory>> GetBookingHistoryAsync()
    {
        var bookings = await _bookingHistoryRepository.ListAsync();
        foreach (var booking in bookings)
        {
            booking.Chats = await _chatService.GetChatsAsync(); // Obtener los chats asociados
            var workers = await _workerService.GetWorkersAsync(); // Obtener los trabajadores asociados
            if (workers != null) {
                foreach (var worker in workers)
                {
                    booking.Workers.Add(worker.Id);
                }
            }
        }
        return bookings;
    }

    /// <summary>
    /// Retrieves a list of bookings associated with a specific client, including associated chat data.
    /// </summary>
    /// <param name="clientId">The identifier of the client.</param>
    /// <returns>The list of bookings with associated chat data for the specified client.</returns>
    public async Task<IEnumerable<BookingHistory>> GetBookingsByClientIdAsync(int clientId)
    {
        var bookings = await _bookingHistoryRepository.ListByClientIdAsync(clientId);
        foreach (var booking in bookings)
        {
            booking.Chats = await _chatService.GetChatsAsync(); // Obtener los chats asociados
            var workers = await _workerService.GetWorkersAsync(); // Obtener los trabajadores asociados
            if (workers != null) {
                foreach (var worker in workers)
                {
                    booking.Workers.Add(worker.Id);
                }
            } // Obtener los trabajadores asociados
        }
        return bookings;
    }

    /// <summary>
    /// Retrieves a list of bookings associated with a specific company, including associated chat data.
    /// </summary>
    /// <param name="companyId">The identifier of the company.</param>
    /// <returns>The list of bookings with associated chat data for the specified company.</returns>
    public async Task<IEnumerable<BookingHistory>> GetBookingsByCompanyIdAsync(int companyId)
    {
        var bookings = await _bookingHistoryRepository.ListByCompanyIdAsync(companyId);
        foreach (var booking in bookings)
        {
            var workers = await _workerService.GetWorkersAsync(); // Obtener los trabajadores asociados
            if (workers != null) {
                foreach (var worker in workers)
                {
                    booking.Workers.Add(worker.Id);
                }
            }
        }
        
        return bookings;
    }

    /// <summary>
    /// Creates a new booking and returns a response.
    /// </summary>
    /// <param name="booking">The booking to be created.</param>
    /// <returns>A response containing the created booking or an error message.</returns>
    public async Task<BookingHistoryResponse> CreateBookingAsync(BookingHistory booking)
    {
        try
        {
            await _bookingHistoryRepository.AddAsync(booking);
            return new BookingHistoryResponse(booking);
        }
        catch (Exception ex)
        {
            return new BookingHistoryResponse($"Error al crear la reserva: {ex.Message}");
        }
    }

    /// <summary>
    /// Updates an existing booking by its identifier and returns a response.
    /// </summary>
    /// <param name="id">The identifier of the booking to be updated.</param>
    /// <param name="booking">The updated booking data.</param>
    /// <returns>A response containing the updated booking or an error message.</returns>
    public async Task<BookingHistoryResponse> UpdateBookingAsync(int id, UpdateBookingHistoryResource booking)
    {
        var existingBooking = await _bookingHistoryRepository.GetAsync(id);

        if (existingBooking == null)
        {
            return new BookingHistoryResponse("Reserva no encontrada.");
        }

        existingBooking.Status = booking.Status;
        existingBooking.Payment = booking.Payment;
        existingBooking.BookingDate = booking.BookingDate;
        existingBooking.PickupAddress = booking.PickupAddress;
        existingBooking.DestinationAddress = booking.DestinationAddress;
        existingBooking.MovingDate = booking.MovingDate;
        existingBooking.MovingTime = booking.MovingTime;

        try
        {
            await _bookingHistoryRepository.UpdateAsync(existingBooking);
            return new BookingHistoryResponse(existingBooking);
        }
        catch (Exception ex)
        {
            return new BookingHistoryResponse($"Error al actualizar la reserva: {ex.Message}");
        }
    }

    //for workers update by comment
    /*public async Task<BookingHistoryResponse> UpdateBookingAsync(int id, UpdateBookingHistoryResourceV2 booking){
        var existingBooking = await _bookingHistoryRepository.GetAsync(id);

        if (existingBooking == null)
        {
            return new BookingHistoryResponse("Reserva no encontrada.");
        }

        existingBooking.Workers = booking.Workers;
        try
        {
            await _bookingHistoryRepository.UpdateAsync(existingBooking);
            return new BookingHistoryResponse(existingBooking);
        }
        catch (Exception ex)
        {
            return new BookingHistoryResponse($"Error al actualizar la reserva: {ex.Message}");
        }

    }*/

}