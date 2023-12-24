using System.ComponentModel.DataAnnotations;

namespace CargaSinEstres.API.Security.Domain.Services.Communication;
/// <summary>
/// Represents a request model for client authentication.
/// </summary>
///<remarks> Grupo 1: Carga sin estres </remarks>
public class AuthenticateRequestClient
{
    /// <summary>
    /// Gets or sets the email address for client authentication.
    /// </summary>
    [Required] public string Email { get; set; }

    /// <summary>
    /// Gets or sets the password for client authentication.
    /// </summary>
    [Required] public string Password { get; set; }
}