using CargaSinEstres.API.CargaSinEstres.Domain.Models;
using CargaSinEstres.API.CargaSinEstres.Domain.Repositories;
using CargaSinEstres.API.CargaSinEstres.Domain.Services;
using CargaSinEstres.API.CargaSinEstres.Domain.Services.Communication;

namespace CargaSinEstres.API.CargaSinEstres.Services;

/// <summary>
/// Service class for handling chat operations.
/// </summary>
///<remarks> Grupo 1: Carga sin estres </remarks>
public class ChatService: IChatService
{
    private readonly IChatRepository _chatRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="ChatService"/> class.
    /// </summary>
    /// <param name="chatRepository">The repository for chat data.</param>
    public ChatService(IChatRepository chatRepository)
    {
        _chatRepository = chatRepository;
    }

    /// <summary>
    /// Retrieves a list of all chats.
    /// </summary>
    /// <returns>The list of all chats.</returns>
    public async Task<IEnumerable<Chat>> GetChatsAsync()
    {
        return await _chatRepository.ListAsync();
    }

    /// <summary>
    /// Retrieves a chat by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the chat to retrieve.</param>
    /// <returns>The chat with the specified identifier.</returns>
    public async Task<Chat> GetChatAsync(int id)
    {
        return await _chatRepository.GetByIdAsync(id);
    }

    /// <summary>
    /// Creates a new chat and returns a response.
    /// </summary>
    /// <param name="chat">The chat to be created.</param>
    /// <returns>A response containing the created chat or an error message.</returns>
    public async Task<ChatResponse> CreateChatAsync(Chat chat)
    {
        try
        {
            await _chatRepository.AddAsync(chat);
            return new ChatResponse(chat);
        }
        catch (Exception ex)
        {
            return new ChatResponse($"Error al crear el chat: {ex.Message}");
        }
    }

    /// <summary>
    /// Updates an existing chat by its identifier and returns a response.
    /// </summary>
    /// <param name="id">The identifier of the chat to be updated.</param>
    /// <param name="chat">The updated chat data.</param>
    /// <returns>A response containing the updated chat or an error message.</returns>
    public async Task<ChatResponse> UpdateChatAsync(int id, Chat chat)
    {
        var existingChat = await _chatRepository.GetByIdAsync(id);

        if (existingChat == null)
        {
            return new ChatResponse("Chat no encontrado.");
        }

        existingChat.User = chat.User;
        existingChat.Message = chat.Message;
        existingChat.DateTime = chat.DateTime;

        try
        {
            await _chatRepository.UpdateAsync(existingChat);
            return new ChatResponse(existingChat);
        }
        catch (Exception ex)
        {
            return new ChatResponse($"Error al actualizar el chat: {ex.Message}");
        }
    }

    /// <summary>
    /// Deletes a chat by its identifier and returns a response.
    /// </summary>
    /// <param name="id">The identifier of the chat to be deleted.</param>
    /// <returns>A response containing the deleted chat or an error message.</returns>
    public async Task<ChatResponse> DeleteChatAsync(int id)
    {
        var existingChat = await _chatRepository.GetByIdAsync(id);

        if (existingChat == null)
        {
            return new ChatResponse("Chat no encontrado.");
        }

        try
        {
            await _chatRepository.RemoveAsync(existingChat);
            return new ChatResponse(existingChat);
        }
        catch (Exception ex)
        {
            return new ChatResponse($"Error al eliminar el chat: {ex.Message}");
        }
    }
}