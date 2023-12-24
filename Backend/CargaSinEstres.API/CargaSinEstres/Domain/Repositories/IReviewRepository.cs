using CargaSinEstres.API.CargaSinEstres.Domain.Models;
using CargaSinEstres.API.CargaSinEstres.Resources;

namespace CargaSinEstres.API.CargaSinEstres.Domain.Repositories;

/// <summary>
/// Represents an interface for a repository for managing review data.
/// </summary>
///<remarks> Grupo 1: Carga sin estres </remarks>
public interface IReviewRepository {

    /// <summary>
    /// Retrieves a list of all reviews asynchronously.
    /// </summary>
    /// <returns>A collection of reviews.</returns>
    Task<IEnumerable<Review>> ListAsync();
    
    /// <summary>
    /// Retrieves reviews associated with a specific company asynchronously.
    /// </summary>
    /// <param name="companyId">The unique identifier of the company.</param>
    /// <returns>A collection of reviews associated with the specified company.</returns>
    Task<IEnumerable<Review>> FindByCompanyIdAsync(int companyId);
    
    /// <summary>
    /// Adds a new review asynchronously.
    /// </summary>
    /// <param name="review">The review to be added.</param>
    Task AddAsync(Review review);
}