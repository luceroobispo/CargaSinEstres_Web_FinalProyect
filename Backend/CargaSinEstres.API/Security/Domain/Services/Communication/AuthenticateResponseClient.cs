namespace CargaSinEstres.API.Security.Domain.Services.Communication;

/// <summary>
/// Represents the response data structure for client authentication in the Carga Sin Estres API.
/// </summary>
/// <remarks> Grupo 1: Carga sin estres </remarks>
public class AuthenticateResponseClient
{
    /// <summary>
    /// Gets or sets the unique identifier of the authenticated client.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the email address of the authenticated client.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Gets or sets the password of the authenticated client.
    /// </summary>
    public string Password { get; set; }
}