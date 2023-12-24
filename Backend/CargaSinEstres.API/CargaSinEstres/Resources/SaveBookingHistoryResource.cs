using System.ComponentModel.DataAnnotations;

namespace CargaSinEstres.API.CargaSinEstres.Resources;

/// <summary>
/// Represents a resource for saving booking history data.
/// </summary>
///<remarks> Grupo 1: Carga sin estres </remarks>
public class SaveBookingHistoryResource
{
    /// <summary>
    /// Gets or sets the booking date. This property is required.
    /// </summary>
    [Required]
    public string BookingDate { get; set; }
    /// <summary>
    /// Gets or sets the pickup address. This property is required.
    /// </summary>
    [Required]
    public string PickupAddress { get; set; }   
    /// <summary>
    /// Gets or sets the destination address. This property is required.
    /// </summary>
    [Required]
    public string DestinationAddress { get; set; }
    /// <summary>
    /// Gets or sets the moving date. This property is required.
    /// </summary>
    [Required]
    public string MovingDate { get; set; }
    /// <summary>
    /// Gets or sets the moving time. This property is required.
    /// </summary>
    [Required]
    public string MovingTime { get; set; }

    /// <summary>
    /// Gets or sets the services. This property is required.
    /// </summary>
    [Required]
    public string Services { get; set; }
    
    /// <summary>
    /// Gets or sets the weight. This property is required.
    /// </summary>
    [Required]
    public int Weight { get; set; }
}

