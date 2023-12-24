namespace CargaSinEstres.API.CargaSinEstres.Resources;

/// <summary>
/// Represents a comment resource.
/// </summary>
///<remarks> Grupo 1: Carga sin estres </remarks>
public class CommentResource
{
    /// <summary>
    /// Gets or sets the identifier of the comment.
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Gets or sets the text content of the comment.
    /// </summary>
    public string CommentText { get; set; }
    /// <summary>
    /// Gets or sets the text content of the booking.
    /// </summary>
    public int BookingId {get; set; }
}