using CargaSinEstres.API.Shared.Persistence.Contexts;

namespace CargaSinEstres.API.Shared.Persistence.Repositories;

/// <summary>
/// Base repository class providing access to the application's DbContext.
/// </summary>
///<remarks> Grupo 1: Carga sin estres </remarks>
public class BaseRepository
{
    /// <summary>
    /// The DbContext for database operations.
    /// </summary>
    protected readonly AppDbContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseRepository"/> class.
    /// </summary>
    /// <param name="context">The application's DbContext.</param>
    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }
}