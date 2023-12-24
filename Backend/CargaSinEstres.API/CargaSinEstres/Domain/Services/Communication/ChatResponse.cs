using CargaSinEstres.API.CargaSinEstres.Domain.Models;
using CargaSinEstres.API.CargaSinEstres.Shared.Domain.Services.Communication;

namespace CargaSinEstres.API.CargaSinEstres.Domain.Services.Communication;

/// <summary>
/// Represents the response from chat service operations.
/// </summary>
///<remarks> Group 1: Carga sin estres </remarks>
public class ChatResponse : BaseResponse<Chat>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ChatResponse"/> class with a message.
    /// </summary>
    /// <param name="message">The response message.</param>
    public ChatResponse(string message) : base(message)
    {
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="ChatResponse"/> class with a chat resource.
    /// </summary>
    /// <param name="resource">The chat resource.</param>
    public ChatResponse(Chat resource) : base(resource)
    {
    }
}

