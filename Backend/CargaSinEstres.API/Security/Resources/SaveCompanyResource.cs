using CargaSinEstres.API.CargaSinEstres.Domain.Models;

namespace CargaSinEstres.API.Security.Resources;

/// <summary>
/// Represents a resource for creating or updating company data.
/// </summary>
public class SaveCompanyResource
{
    /// <summary>
    /// Gets or sets the unique identifier for the company.
    /// </summary>
    public int Id { get; set; }

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
    /// Gets or sets the address of the company.
    /// </summary>
    public string Direccion { get; set; }

    /// <summary>
    /// Gets or sets the contact number of the company.
    /// </summary>
    public string NumeroContacto { get; set; }

    /// <summary>
    /// Gets or sets the password of the company.
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// Gets or sets the confirmation password of the company.
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

    /// <summary>
    /// Gets or sets the user type of the company.
    /// </summary>
    public string UserType { get; set; }

    /// <summary>
    /// Gets or sets the collection of reviews associated with the company.
    /// </summary>
    public IList<Review> Reviews { get; set; } = new List<Review>();
}