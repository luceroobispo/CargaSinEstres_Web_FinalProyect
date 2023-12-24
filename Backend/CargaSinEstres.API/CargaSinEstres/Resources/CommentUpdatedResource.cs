namespace CargaSinEstres.API.CargaSinEstres.Resources;

/// <summary>
/// Represents a resource for updating a comment.
/// </summary>
///<remarks> Grupo 1: Carga sin estres </remarks>
public class CommentUpdatedResource
{
    /// <summary>
    /// Gets or sets the updated text content of the comment.
    /// </summary>
    public string CommentText { get; set; }
    public int BookingId {get; set; }
}