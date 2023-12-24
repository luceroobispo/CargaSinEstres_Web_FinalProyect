using CargaSinEstres.API.Shared.Persistence.Contexts;
using CargaSinEstres.API.Security.Domain.Repositories;
using CargaSinEstres.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CargaSinEstres.API.Security.Persistence.Repositories;

/// <summary>
/// Repository for handling CRUD operations related to companies in the database.
/// </summary>
/// <remarks> Grupo 1: Carga sin estres </remarks>
public class CompanyRepository : BaseRepository, ICompanyRepository
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CompanyRepository"/> class.
    /// </summary>
    /// <param name="context">The application database context.</param>
    public CompanyRepository(AppDbContext context) : base(context)
    {
    }

    /// <summary>
    /// Gets a list of all companies asynchronously.
    /// </summary>
    /// <returns>A task representing the asynchronous operation with the list of companies.</returns>
    public async Task<IEnumerable<Domain.Models.Company>> ListAsync()
    {
        return await _context.Companies.ToListAsync();
    }

    /// <summary>
    /// Adds a new company asynchronously.
    /// </summary>
    /// <param name="company">The company to be added.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task AddAsync(Domain.Models.Company company)
    {
        await _context.Companies.AddAsync(company);
    }

    /// <summary>
    /// Finds a company by its unique identifier asynchronously.
    /// </summary>
    /// <param name="id">The unique identifier of the company.</param>
    /// <returns>A task representing the asynchronous operation with the found company.</returns>
    public async Task<Domain.Models.Company> FindByIdAsync(int id)
    {
        return await _context.Companies.FindAsync(id);
    }

    /// <summary>
    /// Finds a company by its email address asynchronously.
    /// </summary>
    /// <param name="email">The email address of the company.</param>
    /// <returns>A task representing the asynchronous operation with the found company.</returns>
    public async Task<Domain.Models.Company> FindByEmailAsync(string email)
    {
        return await _context.Companies.SingleOrDefaultAsync(x => x.Email == email);
    }

    /// <summary>
    /// Checks if a company with the given email address exists.
    /// </summary>
    /// <param name="email">The email address to check.</param>
    /// <returns>True if a company with the email address exists; otherwise, false.</returns>
    public bool ExistsByEmail(string email)
    {
        return _context.Companies.Any(x => x.Email == email);
    }

    /// <summary>
    /// Finds a company by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the company.</param>
    /// <returns>The found company.</returns>
    public Domain.Models.Company FindById(int id)
    {
        return _context.Companies.Find(id);
    }

    /// <summary>
    /// Updates an existing company.
    /// </summary>
    /// <param name="company">The company to be updated.</param>
    public void Update(Domain.Models.Company company)
    {
        _context.Companies.Update(company);
    }
}