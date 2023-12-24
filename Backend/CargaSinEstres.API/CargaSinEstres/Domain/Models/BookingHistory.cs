using System.ComponentModel.DataAnnotations.Schema;

namespace CargaSinEstres.API.CargaSinEstres.Domain.Models;

/// <summary>
/// Represents a booking history entity that stores information about the reservations made.
/// </summary>
///<remarks> Grupo 1: Carga sin estres </remarks>
public class BookingHistory
{
    /// <summary>
    /// Gets or sets the unique identifier for the booking history.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the company associated with the booking.
    /// </summary>
    public int IdCompany { get; set;}

    /// <summary>
    /// Gets or sets the identifier of the client associated with the booking.
    /// </summary>
    public int IdClient { get; set;}

    /// <summary>
    /// Gets or sets the date when the booking was made.
    /// </summary>
    public string BookingDate { get; set;}

    /// <summary>
    /// Gets or sets the weight. This property is required.
    /// </summary>
    public int Weight { get; set; }
    
    /// <summary>
    /// Gets or sets the pickup address for the booking.
    /// </summary>
    public string PickupAddress { get; set;}

    /// <summary>
    /// Gets or sets the destination address for the booking.
    /// </summary>
    public string DestinationAddress { get; set;}

    /// <summary>
    /// Gets or sets the date when the moving is scheduled.
    /// </summary>
    public string MovingDate {get; set;}

    /// <summary>
    /// Gets or sets the time when the moving is scheduled.
    /// </summary>
    public string MovingTime {get; set;}

    ///<summary>
    /// The services that are reserved for the booking.
    ///</summary>
    public string Services { get; set;}
    
    /// <summary>
    /// Gets or sets the status of the booking (e.g., Finalized, Canceled).
    /// </summary>
    public string Status { get; set;}

     /// <summary>
    /// Gets or sets the total payment amount for the booking.
    /// </summary>   
    public int Payment { get; set; }

    /// <summary>
    /// Gets or sets the collection of chat messages associated with the booking.
    /// </summary>
    public IEnumerable<Chat> Chats { get; set; } = new List<Chat>();
 
    /// <summary>
    /// Gets or sets the list of worker identifiers associated with the booking.
    /// </summary>
    [NotMapped]
    public List<int> Workers { get; set; } = new List<int>();

}