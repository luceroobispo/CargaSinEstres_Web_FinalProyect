using CargaSinEstres.API.CargaSinEstres.Domain.Models;

namespace CargaSinEstres.API.CargaSinEstres.Domain.Repositories;

public interface IMembershipRepository
{
    /// <summary>
    /// Retrieves a list of all memberships asynchronously.
    /// </summary>
    /// <returns>A collection of memberships.</returns>
    Task<IEnumerable<Membership>> ListAsync();
    
    /// <summary>
    /// Retrieves memberships associated with a specific company asynchronously.
    /// </summary>
    /// <param name="companyId">The unique identifier of the company.</param>
    /// <returns>A collection of reviews associated with the specified company.</returns>
    Task<IEnumerable<Membership>> FindByCompanyIdAsync(int companyId);
    
    /// <summary>
    /// Adds a new review asynchronously.
    /// </summary>
    /// <param name="membership">The membership to be added.</param>
    Task AddAsync(Membership membership);
}