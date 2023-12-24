namespace CargaSinEstres.API.CargaSinEstres.Resources;

/// <summary>
/// Represents a resource for saving chat data.
/// </summary>
///<remarks> Grupo 1: Carga sin estres </remarks>
public class SaveChatResource
{
    /// <summary>
    /// Gets or sets the user associated with the chat.
    /// </summary>
    public string User { get; set;}
    /// <summary>
    /// Gets or sets the message associated with the chat.
    /// </summary>
    //message
    public string Message { get; set;}
    /// <summary>
    /// Gets or sets the datetime associated with the chat.
    /// </summary>
    //datetime
    public DateTime DateTime { get; set; }
}