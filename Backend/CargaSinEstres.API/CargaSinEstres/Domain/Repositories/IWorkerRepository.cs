using CargaSinEstres.API.CargaSinEstres.Domain.Models;
using System.Threading.Tasks;

namespace CargaSinEstres.API.CargaSinEstres.Domain.Repositories;

/// <summary>
/// Interface defining the allowed operations in the worker repository.
/// </summary>
///<remarks> Group 1: Carga sin estres </remarks>
public interface IWorkerRepository
{
    /// <summary>
    /// Finds a worker by its identifier asynchronously.
    /// </summary>
    /// <param name="workerId">The identifier of the worker.</param>
    /// <returns>A task representing the operation and containing the found worker.</returns>
    Task<Worker> FindByIdAsync(int workerId);

    /// <summary>
    /// Updates the information of a worker.
    /// </summary>
    /// <param name="worker">The instance of the worker to be updated.</param>
    void Update(Worker worker);

    /// <summary>
    /// Adds a new worker asynchronously.
    /// </summary>
    /// <param name="worker">The worker to be added.</param>
    Task AddAsync(Worker worker);

    /// <summary>
    /// List workers asynchronously.
    /// </summary>
    Task<IEnumerable<Worker>> ListAsync();
}
