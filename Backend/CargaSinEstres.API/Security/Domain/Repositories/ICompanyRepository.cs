namespace CargaSinEstres.API.Security.Domain.Repositories;
/// <summary>
/// Interface defining the allowed operations in the company repository.
/// </summary>
///<remarks> Grupo 1: Carga sin estres </remarks>
public interface ICompanyRepository
{
    /// <summary>
    /// Retrieves a list of all companies asynchronously.
    /// </summary>
    /// <returns>A collection of companies.</returns>
    Task<IEnumerable<Models.Company>> ListAsync();

    /// <summary>
    /// Adds a new company asynchronously.
    /// </summary>
    /// <param name="company">The company to be added.</param>
    Task AddAsync(Models.Company company);

    /// <summary>
    /// Finds a company by its identifier asynchronously.
    /// </summary>
    /// <param name="id">The identifier of the company.</param>
    /// <returns>A task representing the operation and containing the found company.</returns>
    Task<Models.Company> FindByIdAsync(int id);

    /// <summary>
    /// Finds a company by its email address asynchronously.
    /// </summary>
    /// <param name="email">The email address of the company.</param>
    /// <returns>A task representing the operation and containing the found company.</returns>
    Task<Models.Company> FindByEmailAsync(string email);

    /// <summary>
    /// Checks if a company with the given email address exists.
    /// </summary>
    /// <param name="email">The email address to check.</param>
    /// <returns>True if the company exists, otherwise false.</returns>
    public bool ExistsByEmail(string email);

    /// <summary>
    /// Finds a company by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the company.</param>
    /// <returns>The found company.</returns>
    Models.Company FindById(int id);

    /// <summary>
    /// Updates the information of a company.
    /// </summary>
    /// <param name="company">The instance of the company to be updated.</param>
    void Update(Models.Company company);
}