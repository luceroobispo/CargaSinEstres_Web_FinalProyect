using CargaSinEstres.API.CargaSinEstres.Domain.Models;
using CargaSinEstres.API.CargaSinEstres.Domain.Repositories;
using CargaSinEstres.API.Shared.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CargaSinEstres.API.CargaSinEstres.Persistence.Repositories;

/// <summary>
/// Represents a repository for managing chat entities.
/// </summary>
///<remarks> Grupo 1: Carga sin estres </remarks>
public class ChatRepository: IChatRepository
{
    private readonly AppDbContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="ChatRepository"/> class.
    /// </summary>
    /// <param name="context">The application database context.</param>
    public ChatRepository(AppDbContext context)
    {
        _context = context;
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<Chat>> ListAsync()
    {
        return await _context.Chats.ToListAsync();
    }

    /// <inheritdoc/>
    public async Task<Chat> GetByIdAsync(int id)
    {
        return await _context.Chats.FindAsync(id);
    }

    /// <inheritdoc/>
    public async Task AddAsync(Chat chat)
    {
        await _context.Chats.AddAsync(chat);
        await _context.SaveChangesAsync();
    }

    /// <inheritdoc/>
    public async Task UpdateAsync(Chat chat)
    {
        _context.Chats.Update(chat);
        await _context.SaveChangesAsync();
    }

    /// <inheritdoc/>
    public async Task RemoveAsync(Chat chat)
    {
        _context.Chats.Remove(chat);
        await _context.SaveChangesAsync();
    }
}