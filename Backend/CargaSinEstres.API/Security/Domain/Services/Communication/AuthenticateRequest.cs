using System.ComponentModel.DataAnnotations;

namespace CargaSinEstres.API.Security.Domain.Services.Communication;
/// <summary>
/// Represents a request model for authentication.
/// </summary>
///<remarks> Grupo 1: Carga sin estres </remarks>
public class AuthenticateRequest
{
    /// <summary>
    /// Gets or sets the email address for authentication.
    /// </summary>
    [Required] public string Email { get; set; }

    /// <summary>
    /// Gets or sets the password for authentication.
    /// </summary>
    [Required] public string Password { get; set; }

}