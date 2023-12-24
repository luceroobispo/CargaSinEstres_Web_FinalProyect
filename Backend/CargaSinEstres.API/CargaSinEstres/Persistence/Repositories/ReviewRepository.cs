using CargaSinEstres.API.CargaSinEstres.Domain.Models;
using CargaSinEstres.API.CargaSinEstres.Domain.Repositories;
using CargaSinEstres.API.CargaSinEstres.Resources;
using CargaSinEstres.API.Shared.Persistence.Contexts;
using CargaSinEstres.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CargaSinEstres.API.CargaSinEstres.Persistence.Repositories;
/// <summary>
/// Represents a repository for managing review entities.
/// </summary>
///<remarks> Grupo 1: Carga sin estres </remarks>
public class ReviewRepository : BaseRepository, IReviewRepository {
    /// <summary>
    /// Initializes a new instance of the <see cref="ReviewRepository"/> class.
    /// </summary>
    /// <param name="context">The application database context.</param>
    public ReviewRepository(AppDbContext context) : base(context)
    {
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<Review>> ListAsync()
    {
        return await _context.Reviews.ToListAsync();
    }
    
    /// <inheritdoc/>
    public async Task<IEnumerable<Review>> FindByCompanyIdAsync(int companyId)
    {
        return await _context.Reviews
            .Where(p => p.CompanyId == companyId)
            .ToListAsync();
    }

    /// <inheritdoc/>
    public async Task AddAsync(Review review)
    {
        await _context.Reviews.AddAsync(review);
    }
}