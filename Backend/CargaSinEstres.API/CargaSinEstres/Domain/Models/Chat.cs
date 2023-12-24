namespace CargaSinEstres.API.CargaSinEstres.Domain.Models;
/// <summary>
/// Represents a chat message entity containing information such as user, message content, and timestamp.
/// </summary>
///<remarks> Grupo 1: Carga sin estres </remarks>
public class Chat{
    /// <summary>
    /// Gets or sets the unique identifier for the chat message.
    /// </summary>
    public int Id { get; set;}

    /// <summary>
    /// Gets or sets the user associated with the chat message.
    /// </summary>
    public string User { get; set;}
    
    /// <summary>
    /// Gets or sets the content of the chat message.
    /// </summary>
    public string Message { get; set;}

    /// <summary>
    /// Gets or sets the date and time when the chat message was sent.
    /// </summary>
    public DateTime DateTime { get; set; }
    
}