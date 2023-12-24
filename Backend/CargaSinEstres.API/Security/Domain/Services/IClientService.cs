using CargaSinEstres.API.Security.Domain.Models;
using CargaSinEstres.API.Security.Domain.Services.Communication;

namespace CargaSinEstres.API.Security.Domain.Services;
/// <summary>
/// Interface defining the allowed operations in the client service.
/// </summary>
/// <remarks> Grupo 1: Carga sin estres </remarks>
public interface IClientService{
    /// <summary>
    /// Authenticates a client based on the provided credentials.
    /// </summary>
    /// <param name="model">The authentication request model.</param>
    /// <returns>A task representing the authentication response.</returns>
    Task<AuthenticateResponseClient> AuthenticateClient(AuthenticateRequestClient model);

    /// <summary>
    /// Retrieves a list of all clients asynchronously.
    /// </summary>
    /// <returns>A collection of clients.</returns>
    Task<IEnumerable<Client>> ListClientAsync();

    /// <summary>
    /// Retrieves a client by its identifier asynchronously.
    /// </summary>
    /// <param name="id">The identifier of the client.</param>
    /// <returns>A task representing the operation and containing the found client.</returns>
    Task<Client> GetByIdClientAsync(int id);

    /// <summary>
    /// Registers a new client asynchronously.
    /// </summary>
    /// <param name="model">The registration request model.</param>
    /// <returns>A task representing the registration process.</returns>
    Task RegisterClientAsync(RegisterRequestClient model);

    /// <summary>
    /// Updates the information of a client asynchronously.
    /// </summary>
    /// <param name="id">The identifier of the client to be updated.</param>
    /// <param name="model">The update request model.</param>
    /// <returns>A task representing the update process.</returns>
    Task UpdateClientAsync(int id, UpdateRequestClient model);
}