using System.ComponentModel.DataAnnotations;
using CargaSinEstres.API.Security.Resources;

namespace CargaSinEstres.API.CargaSinEstres.Resources;

/// <summary>
/// Represents a resource for a worker.
/// </summary>
///<remarks> Grupo 1: Carga sin estres </remarks>
public class SaveWorkerResource
{
    /// <summary>
    /// Gets or sets the first name of the worker.
    /// </summary>
    [Required]
    public string FirstName { get; set; }
    /// <summary>
    /// Gets or sets the last name of the worker.
    /// </summary>
    [Required]
    public string LastName { get; set; }
}