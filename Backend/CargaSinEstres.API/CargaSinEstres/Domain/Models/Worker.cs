namespace CargaSinEstres.API.CargaSinEstres.Domain.Models;
///<summary>
/// Represents a worker entity with properties such as identifier, first name, last name, company identifier,and a list of comments related to the worker.
///</summary>
///<remarks> Grupo 1: Carga sin estres </remarks>
public class Worker
{
    /// <summary>
    /// Gets or sets the unique identifier for the worker.
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Gets or sets the first name of the worker.
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Gets or sets the last name of the worker.
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the company associated with the worker.
    /// </summary>
    public int CompanyId { get; set; }

    /// <summary>
    /// Gets or sets the list of comments associated with the worker.
    /// </summary>
    public List<Comment> Comments { get; set; } = new List<Comment>();
}