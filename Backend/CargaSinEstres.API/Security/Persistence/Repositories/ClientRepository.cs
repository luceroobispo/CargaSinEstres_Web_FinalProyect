using CargaSinEstres.API.Security.Domain.Models;
using CargaSinEstres.API.Security.Domain.Repositories;
using CargaSinEstres.API.Shared.Persistence.Contexts;
using CargaSinEstres.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CargaSinEstres.API.Security.Persistence.Repositories;

/// <summary>
/// Repository for handling CRUD operations related to clients in the database.
/// </summary>
/// <remarks> Grupo 1: Carga sin estres </remarks>
public class ClientRepository : BaseRepository, IClientRepository
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ClientRepository"/> class.
    /// </summary>
    /// <param name="context">The application database context.</param>
    public ClientRepository(AppDbContext context) : base(context)
    {
    }

    /// <summary>
    /// Gets a list of all clients asynchronously.
    /// </summary>
    /// <returns>A task representing the asynchronous operation with the list of clients.</returns>
    public async Task<IEnumerable<Client>> ListClientAsync()
    {
        return await _context.Clients.ToListAsync();
    }

    /// <summary>
    /// Adds a new client asynchronously.
    /// </summary>
    /// <param name="client">The client to be added.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task AddClientAsync(Client client)
    {
        await _context.Clients.AddAsync(client);
    }

    /// <summary>
    /// Finds a client by its unique identifier asynchronously.
    /// </summary>
    /// <param name="id">The unique identifier of the client.</param>
    /// <returns>A task representing the asynchronous operation with the found client.</returns>
    public async Task<Client> FindByIdClientAsync(int id)
    {
       return await _context.Clients.FindAsync(id);
    }

    /// <summary>
    /// Finds a client by its email address asynchronously.
    /// </summary>
    /// <param name="email">The email address of the client.</param>
    /// <returns>A task representing the asynchronous operation with the found client.</returns>
    public async Task<Client> FindByEmailClientAsync(string email)
    {
        return await _context.Clients.SingleOrDefaultAsync(x => x.Email == email);
    }
    
    public async Task<Client> FindByEmailAndPasswordClientAsync(string email, string password)
    {
        return await _context.Clients.SingleOrDefaultAsync(x => x.Email == email && x.Password == password);
    }

    /// <summary>
    /// Checks if a client with the given email address exists.
    /// </summary>
    /// <param name="email">The email address to check.</param>
    /// <returns>True if a client with the email address exists; otherwise, false.</returns>
    public bool ExistsByEmailClient(string email)
    {
        return _context.Clients.Any(x => x.Email == email);
    }

    /// <summary>
    /// Finds a client by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the client.</param>
    /// <returns>The found client.</returns>
    public Client FindByIdClient(int id)
    {
        return _context.Clients.Find(id);
    }

    /// <summary>
    /// Updates an existing client.
    /// </summary>
    /// <param name="client">The client to be updated.</param>
    public void UpdateClient(Client client)
    {
        _context.Clients.Update(client);
    }
}