using System.ComponentModel.DataAnnotations.Schema;
using CargaSinEstres.API.CargaSinEstres.Domain.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace CargaSinEstres.API.CargaSinEstres.Resources;

/// <summary>
/// Represents booking history data.
/// </summary>
///<remarks> Grupo 1: Carga sin estres </remarks>
public class BookingHistoryResource
{
    /// <summary>
    /// Gets or sets the identifier of the booking.
    /// </summary>
    [SwaggerSchema("Booking Identifier")]
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the company.
    /// </summary>
    [SwaggerSchema("Company Identifier")]
    public int IdCompany { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the client.
    /// </summary>
    [SwaggerSchema("Client Identifier")]
    public int IdClient { get; set; }

    /// <summary>
    /// Gets or sets the date of the booking.
    /// </summary>
    [SwaggerSchema("Booking Date")]
    public string BookingDate { get; set; }

    /// <summary>
    /// Gets or sets the pickup address.
    /// </summary>
    [SwaggerSchema("Pickup Address")]
    public string PickupAddress { get; set; }

    /// <summary>
    /// Gets or sets the destination address.
    /// </summary>
    [SwaggerSchema("Destination Address")]
    public string DestinationAddress { get; set; }

    /// <summary>
    /// Gets or sets the moving date.
    /// </summary>
    [SwaggerSchema("Moving Date")]
    public string MovingDate { get; set; }
    
    /// <summary>
    /// Gets or sets the moving time.
    /// </summary>
    [SwaggerSchema("Moving Time")]
    public string MovingTime {get; set;}

    /// <summary>
    /// Gets or sets the booking status.
    /// </summary>
    [SwaggerSchema("Booking Status")]
    public string Status { get; set; }
    
    /// <summary>
    /// Gets or sets the payment amount.
    /// </summary>
    [SwaggerSchema("Payment")]
    public int Payment { get; set; }
    
    /// <summary>
    /// Gets or sets the weight. This property is required.
    /// </summary>
    [SwaggerSchema("Weight")]
    public int Weight { get; set; }
    
    /// <summary>
    /// Gets or sets the list of chats associated with the booking.
    /// </summary>
    [SwaggerSchema("Chats")]
    public List<Chat> Chats { get; set; }

    /// <summary>
    /// Gets or sets the list of worker identifiers associated with the booking.
    /// </summary>
    [SwaggerSchema("Workers")]
    public List<int> Workers { get; set; }

    /// <summary>
    /// Gets or sets the services
    /// </summary>
    [SwaggerSchema("Services")]
    public string Services { get; set;}
}