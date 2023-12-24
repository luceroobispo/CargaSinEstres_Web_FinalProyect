namespace CargaSinEstres.API.CargaSinEstres.Shared.Domain.Services.Communication;

/// <summary>
/// Represents the base response for communication from services, indicating success or failure.
/// </summary>
/// <typeparam name="T">The type of the associated resource.</typeparam>
///<remarks> Grupo 1: Carga sin estres </remarks>
public abstract class BaseResponse<T>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BaseResponse{T}"/> class indicating failure.
    /// </summary>
    /// <param name="message">The message describing the failure.</param>
    protected BaseResponse(string message)
    {
        Success = false;
        Message = message;
        Resource = default;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseResponse{T}"/> class indicating success.
    /// </summary>
    /// <param name="resource">The associated resource in case of success.</param>
    protected BaseResponse(T resource)
    { 
        Success = true;
        Message = string.Empty; 
        Resource = resource;
    }

    /// <summary>
    /// Gets a value indicating whether the operation was successful.
    /// </summary>
    public bool Success { get; set; }

    /// <summary>
    /// Gets or sets the message describing the result of the operation.
    /// </summary>
    public string Message { get; set; }

    /// <summary>
    /// Gets or sets the associated resource.
    /// </summary>
    public T Resource { get; set; }
}