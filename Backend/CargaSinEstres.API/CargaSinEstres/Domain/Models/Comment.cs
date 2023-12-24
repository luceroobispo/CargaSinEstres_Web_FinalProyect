namespace CargaSinEstres.API.CargaSinEstres.Domain.Models;
/// <summary>
/// Represents a comment entity with properties such as identifier, comment text, and a foreign key relationship with a worker.
/// </summary>
///<remarks> Grupo 1: Carga sin estres </remarks>
public class Comment
{
    /// <summary>
    /// Gets or sets the unique identifier for the comment.
    /// </summary>   
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the text content of the comment.
    /// </summary>
    public string CommentText { get; set; }

    /// <summary>
    /// Gets or sets the foreign key referencing the associated worker.
    /// </summary>    
    public int WorkerId { get; set; }

    /// <summary>
    /// Gets or sets the worker associated with the comment.
    /// </summary>
    public Worker Worker { get; set; }

    /// <summary>
    /// Gets or sets the booking associated with the comment.
    /// </summary>
    public int BookingId {get; set; }
}