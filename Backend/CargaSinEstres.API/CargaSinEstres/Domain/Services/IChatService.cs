using CargaSinEstres.API.CargaSinEstres.Domain.Models;
using CargaSinEstres.API.CargaSinEstres.Domain.Services.Communication;

namespace CargaSinEstres.API.CargaSinEstres.Domain.Services;

/// <summary>
/// Represents a service for managing chat entities.
/// </summary>
///<remarks> Grupo 1: Carga sin estres </remarks>
public interface IChatService
{
    /// <summary>
    /// Gets a list of all chat entities asynchronously.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of chat entities.</returns>
    Task<IEnumerable<Chat>> GetChatsAsync();

    /// <summary>
    /// Gets a chat entity asynchronously by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the chat entity.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the chat entity.</returns>
    Task<Chat> GetChatAsync(int id);

    /// <summary>
    /// Creates a new chat entity asynchronously.
    /// </summary>
    /// <param name="chat">The chat entity to be created.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a response with the created chat entity.</returns>
    Task<ChatResponse> CreateChatAsync(Chat chat);

    /// <summary>
    /// Updates an existing chat entity asynchronously.
    /// </summary>
    /// <param name="id">The unique identifier of the chat entity to be updated.</param>
    /// <param name="chat">The updated chat entity.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a response with the updated chat entity.</returns>
    Task<ChatResponse> UpdateChatAsync(int id, Chat chat);

    /// <summary>
    /// Deletes a chat entity asynchronously by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the chat entity to be deleted.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a response with the deleted chat entity.</returns>
    Task<ChatResponse> DeleteChatAsync(int id);
}