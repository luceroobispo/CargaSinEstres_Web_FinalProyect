using CargaSinEstres.API.CargaSinEstres.Domain.Models;
using CargaSinEstres.API.CargaSinEstres.Shared.Domain.Services.Communication;

namespace CargaSinEstres.API.CargaSinEstres.Domain.Services.Communication;

/// <summary>
/// Represents a response for worker-related operations, including a message and the worker resource.
/// </summary>
///<remarks> Grupo 1: Carga sin estres </remarks>
public class WorkerResponse : BaseResponse<Worker>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="WorkerResponse"/> class with a message.
    /// </summary>
    /// <param name="message">The response message.</param>
    public WorkerResponse(string message) : base(message)
    {
        
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="WorkerResponse"/> class with a worker resource.
    /// </summary>
    /// <param name="resource">The worker resource.</param>
    public WorkerResponse(Worker resource) : base(resource)
    {
        
    }
}