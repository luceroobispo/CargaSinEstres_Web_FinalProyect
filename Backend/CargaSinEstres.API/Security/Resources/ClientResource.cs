namespace CargaSinEstres.API.Security.Resources;

/// <summary>
/// Represents a data transfer object (DTO) for presenting client information.
/// </summary>
///<remarks> Grupo 1: Carga sin estres </remarks>
public class ClientResource
{
    /// <summary>
    /// Gets or sets the unique identifier for the client.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the client.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the email address of the client.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Gets or sets the password of the client.
    /// </summary>
    public string Password { get; set; }
    
    /// <summary>
    /// Gets or sets the client's address.
    /// </summary>
    public string Direccion { get; set; }
}