using CargaSinEstres.API.Security.Domain.Services.Communication;
using CargaSinEstres.API.Security.Resources;

namespace CargaSinEstres.API.Security.Domain.Services;
/// <summary>
/// Interface defining the allowed operations in the company service.
/// </summary>
///<remarks> Grupo 1: Carga sin estres </remarks>
public interface ICompanyService
{
    /// <summary>
    /// Authenticates a company based on the provided credentials.
    /// </summary>
    /// <param name="model">The authentication request model.</param>
    /// <returns>A task representing the authentication response.</returns>
    Task<AuthenticateResponse> Authenticate(AuthenticateRequest model);

    /// <summary>
    /// Retrieves a list of all companies asynchronously.
    /// </summary>
    /// <returns>A collection of companies.</returns>
    Task<IEnumerable<Models.Company>> ListAsync();

    /// <summary>
    /// Retrieves a company by its identifier asynchronously.
    /// </summary>
    /// <param name="id">The identifier of the company.</param>
    /// <returns>A task representing the operation and containing the found company.</returns>
    Task<Models.Company> GetByIdAsync(int id);

    /// <summary>
    /// Registers a new company asynchronously.
    /// </summary>
    /// <param name="model">The registration request model.</param>
    /// <returns>A task representing the registration process.</returns>
    Task RegisterAsync(RegisterRequest model);

    /// <summary>
    /// Updates the information of a company asynchronously.
    /// </summary>
    /// <param name="id">The identifier of the company to be updated.</param>
    /// <param name="model">The update request model.</param>
    /// <returns>A task representing the update process.</returns>
    Task UpdateAsync(int id, UpdateRequest model);
    
    //Task<CompanyResource> GetByEmailAndPasswordAsync(string email, string password);
    
    
}