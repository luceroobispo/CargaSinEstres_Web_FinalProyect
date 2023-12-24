using CargaSinEstres.API.Security.Domain.Models;

namespace CargaSinEstres.API.Security.Domain.Repositories;
/// <summary>
/// Interface defining the allowed operations in the client repository.
/// </summary>
///<remarks> Grupo 1: Carga sin estres </remarks>
public interface IClientRepository {
    /// <summary>
    /// Retrieves a list of all clients asynchronously.
    /// </summary>
    /// <returns>A collection of clients.</returns>
    Task<IEnumerable<Client>> ListClientAsync();

    /// <summary>
    /// Adds a new client asynchronously.
    /// </summary>
    /// <param name="client">The client to be added.</param>
    Task AddClientAsync(Client client);

    /// <summary>
    /// Finds a client by its identifier asynchronously.
    /// </summary>
    /// <param name="id">The identifier of the client.</param>
    /// <returns>A task representing the operation and containing the found client.</returns>
    Task<Client> FindByIdClientAsync(int id);

    /// <summary>
    /// Finds a client by its email address asynchronously.
    /// </summary>
    /// <param name="email">The email address of the client.</param>
    /// <returns>A task representing the operation and containing the found client.</returns>
    Task<Client> FindByEmailClientAsync(string email);

    /// <summary>
    /// Checks if a client with the given email address exists.
    /// </summary>
    /// <param name="email">The email address to check.</param>
    /// <returns>True if the client exists, otherwise false.</returns>
    public bool ExistsByEmailClient(string email);

    /// <summary>
    /// Finds a client by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the client.</param>
    /// <returns>The found client.</returns>
    Client FindByIdClient(int id);

    /// <summary>
    /// Updates the information of a client.
    /// </summary>
    /// <param name="client">The instance of the client to be updated.</param>
    void UpdateClient(Client client);
}