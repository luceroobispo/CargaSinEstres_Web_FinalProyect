using CargaSinEstres.API.CargaSinEstres.Domain.Repositories;
using CargaSinEstres.API.Shared.Persistence.Contexts;

namespace CargaSinEstres.API.Shared.Persistence.Repositories;

/// <summary>
/// Implementation of the Unit of Work pattern for managing database transactions.
/// </summary>
///<remarks> Grupo 1: Carga sin estres </remarks>
public class UnitOfWork : IUnitOfWork
{
    /// <summary>
    /// The application's DbContext for database operations.
    /// </summary>
    private readonly AppDbContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
    /// </summary>
    /// <param name="context">The application's DbContext.</param>
    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Commits changes to the database asynchronously.
    /// </summary>
    /// <returns>A Task representing the asynchronous operation.</returns>
    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }
}