using CargaSinEstres.API.CargaSinEstres.Domain.Models;
using CargaSinEstres.API.CargaSinEstres.Domain.Repositories;
using CargaSinEstres.API.Shared.Persistence.Contexts;
using CargaSinEstres.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CargaSinEstres.API.CargaSinEstres.Persistence.Repositories;
/// <summary>
/// Represents a repository for managing membership entities.
/// </summary>
///<remarks> Grupo 1: Carga sin estres </remarks>
public class MembershipRepository : BaseRepository, IMembershipRepository
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MembershipRepository"/> class.
    /// </summary>
    /// <param name="context">The application database context.</param>
    public MembershipRepository(AppDbContext context) : base(context)
    {
    }

    /// <summary>
    /// Retrieves a list of all memberships asynchronously.
    /// </summary>
    /// <returns>A collection of memberships.</returns>
    public async Task<IEnumerable<Membership>> ListAsync()
    {
        return await _context.Memberships.ToListAsync();
    }

    /// <summary>
    /// Retrieves memberships associated with a specific company asynchronously.
    /// </summary>
    /// <param name="companyId">The unique identifier of the company.</param>
    /// <returns>A collection of memberships associated with the specified company.</returns>
    public async Task<IEnumerable<Membership>> FindByCompanyIdAsync(int companyId)
    {
        return await _context.Memberships
            .Where(m => m.IdCompany == companyId)
            .ToListAsync();
    }

    /// <summary>
    /// Adds a new membership asynchronously.
    /// </summary>
    /// <param name="membership">The membership to be added.</param>
    public async Task AddAsync(Membership membership)
    {
        await _context.Memberships.AddAsync(membership);
    }
}