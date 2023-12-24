using System.ComponentModel.DataAnnotations;

namespace CargaSinEstres.API.Security.Domain.Services.Communication;

/// <summary>
/// Represents the data structure for registering a client in the Carga Sin Estres API.
/// </summary>
/// <remarks> Grupo 1: Carga sin estres </remarks>
public class RegisterRequestClient
{
    /// <summary>
    /// Gets or sets the first name of the client.
    /// </summary>
    [Required]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the last name (paternal) of the client.
    /// </summary>
    [Required]
    public string ApellidoPaterno { get; set; }

    /// <summary>
    /// Gets or sets the last name (maternal) of the client.
    /// </summary>
    [Required]
    public string ApellidoMaterno { get; set; }

    /// <summary>
    /// Gets or sets the phone number of the client.
    /// </summary>
    [Required]
    public string Celular { get; set; }

    /// <summary>
    /// Gets or sets the address of the client.
    /// </summary>
    [Required]
    public string Direccion { get; set; }

    /// <summary>
    /// Gets or sets the email address of the client.
    /// </summary>
    [Required]
    public string Email { get; set; }

    /// <summary>
    /// Gets or sets the password of the client.
    /// </summary>
    [Required]
    public string Password { get; set; }
    
    /// <summary>
    /// Gets or sets the user type of the company.
    /// </summary>
    [Required]
    public string UserType { get; set; }
}