using CargaSinEstres.API.CargaSinEstres.Domain.Models;
using CargaSinEstres.API.CargaSinEstres.Domain.Repositories;
using CargaSinEstres.API.Shared.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CargaSinEstres.API.CargaSinEstres.Persistence.Repositories;
/// <summary>
/// Represents a repository for managing comment entities.
/// </summary>
///<remarks> Grupo 1: Carga sin estres </remarks>
public class CommentRepository: ICommentRepository
{
    private readonly AppDbContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="CommentRepository"/> class.
    /// </summary>
    /// <param name="context">The application database context.</param>
    public CommentRepository(AppDbContext context)
    {
        _context = context;
    }

    /// <inheritdoc/>
    public async Task AddAsync(Comment comment)
    {
        await _context.Comments.AddAsync(comment);
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<Comment>> ListByWorkerIdAsync(int workerId)
    {
        return await _context.Comments
            .Where(p => p.WorkerId == workerId)
            .ToListAsync();
    }
}