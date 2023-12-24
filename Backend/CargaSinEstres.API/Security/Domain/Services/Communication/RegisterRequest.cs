using System.ComponentModel.DataAnnotations;

namespace CargaSinEstres.API.Security.Domain.Services.Communication;

/// <summary>
/// Represents the data structure for registering a company in the Carga Sin Estres API.
/// </summary>
/// <remarks> Grupo 1: Carga sin estres </remarks>
public class RegisterRequest
{
    /// <summary>
    /// Gets or sets the name of the company.
    /// </summary>
    [Required]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the photo URL of the company.
    /// </summary>
    [Required]
    public string Photo { get; set; }

    /// <summary>
    /// Gets or sets the email address of the company.
    /// </summary>
    [Required]
    public string Email { get; set; }

    /// <summary>
    /// Gets or sets the password of the company.
    /// </summary>
    [Required]
    public string Password { get; set; }

    /// <summary>
    /// Gets or sets the address of the company.
    /// </summary>
    [Required]
    public string Direccion { get; set; }

    /// <summary>
    /// Gets or sets the contact number of the company.
    /// </summary>
    [Required]
    public string NumeroContacto { get; set; }

    /// <summary>
    /// Gets or sets the confirmed password of the company.
    /// </summary>
    [Required]
    public string ConfirmarPassword { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the company provides transportation services.
    /// </summary>
    [Required]
    public bool Transporte { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the company provides cargo services.
    /// </summary>
    [Required]
    public bool Carga { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the company provides packaging services.
    /// </summary>
    [Required]
    public bool Embalaje { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the company provides assembly services.
    /// </summary>
    [Required]
    public bool Montaje { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the company provides disassembly services.
    /// </summary>
    [Required]
    public bool Desmontaje { get; set; }

    /// <summary>
    /// Gets or sets the description of the company.
    /// </summary>
    [Required]
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets the user type of the company.
    /// </summary>
    [Required]
    public string UserType { get; set; }
}