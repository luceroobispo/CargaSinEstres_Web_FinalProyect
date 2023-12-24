using CargaSinEstres.API.CargaSinEstres.Domain.Models;
using CargaSinEstres.API.CargaSinEstres.Shared.Domain.Services.Communication;

namespace CargaSinEstres.API.CargaSinEstres.Domain.Services.Communication;

/// <summary>
/// Represents the response from booking history service operations.
/// </summary>
///<remarks> Grupo 1: Carga sin estres </remarks>
public class BookingHistoryResponse : BaseResponse<BookingHistory>{
   
    /// <summary>
    /// Initializes a new instance of the <see cref="BookingHistoryResponse"/> class with a message.
    /// </summary>
    /// <param name="message">The response message.</param>
    public BookingHistoryResponse(string message) : base(message)
    {
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="BookingHistoryResponse"/> class with a booking history resource.
    /// </summary>
    /// <param name="resource">The booking history resource.</param>
    public BookingHistoryResponse(BookingHistory resource) : base(resource)
    {
    }
}