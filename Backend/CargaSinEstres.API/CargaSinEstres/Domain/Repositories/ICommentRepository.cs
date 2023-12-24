using CargaSinEstres.API.CargaSinEstres.Domain.Models;

namespace CargaSinEstres.API.CargaSinEstres.Domain.Repositories;
/// <summary>
/// Represents a repository for managing comment entities.
/// </summary>
///<remarks> Grupo 1: Carga sin estres </remarks>
public interface ICommentRepository 
{
    /// <summary>
    /// Adds a new comment entity asynchronously.
    /// </summary>
    /// <param name="comment">The comment entity to be added.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task AddAsync(Comment comment);

    /// <summary>
    /// Gets a list of comments associated with a worker asynchronously.
    /// </summary>
    /// <param name="workerId">The identifier of the worker.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of comment entities.</returns>
    Task<IEnumerable<Comment>> ListByWorkerIdAsync(int workerId);
}