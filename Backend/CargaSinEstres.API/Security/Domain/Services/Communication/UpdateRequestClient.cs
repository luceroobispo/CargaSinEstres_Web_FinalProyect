namespace CargaSinEstres.API.Security.Domain.Services.Communication;

/// <summary>
/// Represents the data structure for updating client information in the Carga Sin Estres API.
/// </summary>
/// <remarks> Grupo 1: Carga sin estres </remarks>
public class UpdateRequestClient
{
    /// <summary>
    /// Gets or sets the first name of the client.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the last name of the client.
    /// </summary>
    public string ApellidoPaterno { get; set; }

    /// <summary>
    /// Gets or sets the second last name of the client.
    /// </summary>
    public string ApellidoMaterno { get; set; }

    /// <summary>
    /// Gets or sets the client's phone number.
    /// </summary>
    public string Celular { get; set; }

    /// <summary>
    /// Gets or sets the client's address.
    /// </summary>
    public string Direccion { get; set; }

    /// <summary>
    /// Gets or sets the client's email address.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Gets or sets the client's password.
    /// </summary>
    public string Password { get; set; }
}