using System.ComponentModel.DataAnnotations.Schema;
using CargaSinEstres.API.CargaSinEstres.Domain.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace CargaSinEstres.API.CargaSinEstres.Resources;

/// <summary>
/// Represents a resource for updating booking history data.
/// </summary>
///<remarks> Grupo 1: Carga sin estres </remarks>
public class UpdateBookingHistoryResource
{
    /// <summary>
    /// Gets or sets the updated booking date.
    /// </summary>
    public string BookingDate { get; set; }
    /// <summary>
    /// Gets or sets the updated pickup address.
    /// </summary>
    public string PickupAddress { get; set; }
    /// <summary>
    /// Gets or sets the updated destination address.
    /// </summary>
    public string DestinationAddress { get; set; }
    /// <summary>
    /// Gets or sets the updated moving date.
    /// </summary>
    public string MovingDate { get; set; }
    /// <summary>
    /// Gets or sets the updated moving time.
    /// </summary>
    public string MovingTime { get; set; }
    /// <summary>
    /// Gets or sets the updated booking status.
    /// </summary>
    public string Status { get; set; }
    /// <summary>
    /// Gets or sets the updated payment amount.
    /// </summary>
    public int Payment { get; set; }
}

