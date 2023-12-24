using CargaSinEstres.API.CargaSinEstres.Domain.Models;
using CargaSinEstres.API.CargaSinEstres.Domain.Repositories;
using CargaSinEstres.API.Shared.Persistence.Contexts;
using CargaSinEstres.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CargaSinEstres.API.CargaSinEstres.Persistence.Repositories;
/// <summary>
/// Represents a repository for managing worker entities.
/// </summary>
///<remarks> Grupo 1: Carga sin estres </remarks>
public class WorkerRepository : BaseRepository, IWorkerRepository
{
     /// <summary>
    /// Initializes a new instance of the <see cref="WorkerRepository"/> class.
    /// </summary>
    /// <param name="context">The application database context.</param>
    public WorkerRepository(AppDbContext context) : base(context) {}

    /// <inheritdoc/>
    public async Task<Worker> FindByIdAsync(int id)
    {
        return await _context.Workers
            .Include(c => c.Comments) // Si deseas cargar también los comentarios
            .SingleOrDefaultAsync(c => c.Id == id);
    }

    /// <inheritdoc/> 
    public void Update(Worker worker)
    {
        _context.Workers.Update(worker);
    }
    
    /// <inheritdoc/>
    public async Task AddAsync(Worker worker)
    {
        await _context.Workers.AddAsync(worker);
    }
    
    public async Task<IEnumerable<Worker>> ListAsync()
    {
        return await _context.Workers.ToListAsync();
    }
}