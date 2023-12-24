using System.ComponentModel.DataAnnotations;

namespace CargaSinEstres.API.CargaSinEstres.Resources;

/// <summary>
/// Represents a resource for saving booking history worker data.
/// </summary>
///<remarks> Grupo 1: Carga sin estres </remarks>
public class SaveBookingHistoryResourceV2
{
    /// <summary>
    /// Gets or sets the list of worker identifiers associated with the booking.
    /// </summary>
    [Required]
    public List<int> Workers { get; set; } = new List<int>();
}

