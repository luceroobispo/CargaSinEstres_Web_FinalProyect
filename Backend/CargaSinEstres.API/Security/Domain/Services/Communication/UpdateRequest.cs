using CargaSinEstres.API.CargaSinEstres.Domain.Models;

namespace CargaSinEstres.API.Security.Domain.Services.Communication;

/// <summary>
/// Represents the data structure for updating company information in the Carga Sin Estres API.
/// </summary>
/// <remarks> Grupo 1: Carga sin estres </remarks>
public class UpdateRequest
{
    /// <summary>
    /// Gets or sets the name of the company.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the photo of the company.
    /// </summary>
    public string Photo { get; set; }

    /// <summary>
    /// Gets or sets the email address of the company.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Gets or sets the password of the company.
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// Gets or sets the address of the company.
    /// </summary>
    public string Direccion { get; set; }

    /// <summary>
    /// Gets or sets the contact number of the company.
    /// </summary>
    public string NumeroContacto { get; set; }

    /// <summary>
    /// Gets or sets the confirmed password of the company.
    /// </summary>
    public string ConfirmarPassword { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the company provides transportation services.
    /// </summary>
    public bool Transporte { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the company provides cargo services.
    /// </summary>
    public bool Carga { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the company provides packaging services.
    /// </summary>
    public bool Embalaje { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the company provides assembly services.
    /// </summary>
    public bool Montaje { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the company provides disassembly services.
    /// </summary>
    public bool Desmontaje { get; set; }

    /// <summary>
    /// Gets or sets the description of the company.
    /// </summary>
    public string Description { get; set; }
}