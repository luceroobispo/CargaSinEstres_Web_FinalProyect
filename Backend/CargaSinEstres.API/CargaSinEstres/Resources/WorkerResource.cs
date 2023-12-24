using CargaSinEstres.API.Security.Resources;

namespace CargaSinEstres.API.CargaSinEstres.Resources;

/// <summary>
/// Represents a resource for a worker.
/// </summary>
///<remarks> Grupo 1: Carga sin estres </remarks>
public class WorkerResource
{
    /// <summary>
    /// Gets or sets the identifier of the worker.
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
    /// Gets or sets the identifier of the company to which the worker belongs.
    /// </summary>
    public int CompanyId { get; set; }
    /// <summary>
    /// Gets or sets the list of comments associated with the worker.
    /// </summary>
    public IList<CommentResource> Comments { get; set; } = new List<CommentResource>();
}