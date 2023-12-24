using CargaSinEstres.API.CargaSinEstres.Domain.Models;
using CargaSinEstres.API.CargaSinEstres.Domain.Services.Communication;
using CargaSinEstres.API.CargaSinEstres.Resources;

namespace CargaSinEstres.API.CargaSinEstres.Domain.Services;
/// <summary>
/// Represents a service for managing worker entities.
/// </summary>
///<remarks> Grupo 1: Carga sin estres </remarks>
public interface IWorkerService
{
    /// <summary>
    /// Updates comments for a worker asynchronously.
    /// </summary>
    /// <param name="id">The unique identifier of the worker.</param>
    /// <param name="updateCommentResource">The resource containing updated comments for the worker.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a response with the updated worker entity.</returns>
    Task<WorkerResponse> UpdateCommentsAsync(int id, UpdateCommentResource updateCommentResource);

    /// <summary>
    /// Gets a worker entity asynchronously by its unique identifier.
    /// </summary>
    /// <param name="workerId">The identifier of the worker.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the worker entity.</returns>
    Task<Worker> ListByWorkerIdAsync(int workerId);

    /// <summary>
    /// Saves a new worker entity asynchronously.
    /// </summary>
    /// <param name="worker">The worker entity to be saved.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a response with the saved worker entity.</returns>
    Task<WorkerResponse> SaveAsync(Worker worker);

    /// <summary>
    /// Gets a list of all workers entities asynchronously.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of workers entities.</returns>
    Task<IEnumerable<Worker>> GetWorkersAsync();
}