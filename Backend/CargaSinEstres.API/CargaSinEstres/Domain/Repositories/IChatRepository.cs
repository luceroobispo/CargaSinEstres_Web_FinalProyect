using CargaSinEstres.API.CargaSinEstres.Domain.Models;

namespace CargaSinEstres.API.CargaSinEstres.Domain.Repositories;

/// <summary>
/// Represents a repository for managing chat entities.
/// </summary>
///<remarks> Grupo 1: Carga sin estres </remarks>
public interface IChatRepository
{
    /// <summary>
    /// Gets a list of all chat entities asynchronously.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of chat entities.</returns>
    Task<IEnumerable<Chat>> ListAsync();

    /// <summary>
    /// Gets a chat entity asynchronously by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the chat entity.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the chat entity.</returns>
    Task<Chat> GetByIdAsync(int id);


    /// <summary>
    /// Adds a new chat entity asynchronously.
    /// </summary>
    /// <param name="chat">The chat entity to be added.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task AddAsync(Chat chat);

    /// <summary>
    /// Updates an existing chat entity asynchronously.
    /// </summary>
    /// <param name="chat">The chat entity to be updated.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task UpdateAsync(Chat chat);

    /// <summary>
    /// Removes a chat entity asynchronously.
    /// </summary>
    /// <param name="chat">The chat entity to be removed.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task RemoveAsync(Chat chat);
}