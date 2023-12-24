using CargaSinEstres.API.CargaSinEstres.Domain.Models;
using CargaSinEstres.API.CargaSinEstres.Domain.Repositories;
using CargaSinEstres.API.Shared.Persistence.Contexts;
using CargaSinEstres.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CargaSinEstres.API.CargaSinEstres.Persistence.Repositories;
/// <summary>
/// Represents a repository for managing booking history entities.
/// </summary>
///<remarks> Grupo 1: Carga sin estres </remarks>
public class BookingHistoryRepository : BaseRepository, IBookingHistoryRepository
{
    private readonly AppDbContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="BookingHistoryRepository"/> class.
    /// </summary>
    /// <param name="context">The application database context.</param>
    public BookingHistoryRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    /// <inheritdoc/>
    public async Task<BookingHistory> GetAsync(int id)
    {
        return await _context.BookingHistories.FindAsync(id);
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<BookingHistory>> ListAsync()
    {
        return await _context.BookingHistories.ToListAsync();
    }

    /// <inheritdoc/>
     public async Task<IEnumerable<BookingHistory>> ListByClientIdAsync(int clientId)
    {
        return await _context.BookingHistories
            .Where(p => p.IdClient == clientId)
            .ToListAsync();
    }
    
    /// <inheritdoc/>
    public async Task<IEnumerable<BookingHistory>> ListByCompanyIdAsync(int companyId)
    {
        return await _context.BookingHistories
            .Where(p => p.IdCompany == companyId)
            .ToListAsync();
    }
    
    /// <inheritdoc/>
    public async Task AddAsync(BookingHistory booking)
    {
        await _context.BookingHistories.AddAsync(booking);
        await _context.SaveChangesAsync();
    }

    /// <inheritdoc/>
    public async Task UpdateAsync(BookingHistory booking)
    {
        _context.BookingHistories.Update(booking);
        await _context.SaveChangesAsync();
    }

    /// <inheritdoc/>
    public async Task RemoveAsync(BookingHistory booking)
    {
        _context.BookingHistories.Remove(booking);
        await _context.SaveChangesAsync();
    }
}
