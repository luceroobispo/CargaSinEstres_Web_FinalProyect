using CargaSinEstres.API.CargaSinEstres.Domain.Models;
using CargaSinEstres.API.CargaSinEstres.Shared.Domain.Services.Communication;

namespace CargaSinEstres.API.CargaSinEstres.Domain.Services.Communication;

/// <summary>
/// Represents the response from comment service operations.
/// </summary>
///<remarks> Grupo 1: Carga sin estres </remarks>
public class CommentResponse : BaseResponse<Comment>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CommentResponse"/> class with a message.
    /// </summary>
    /// <param name="message">The response message.</param>
    public CommentResponse(string message) : base(message)
    {
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="CommentResponse"/> class with a comment resource.
    /// </summary>
    /// <param name="resource">The comment resource.</param>
    public CommentResponse(Comment resource) : base(resource)
    {
    }
}

