namespace CargaSinEstres.API.Security.Domain.Services.Communication;
/// <summary>
/// Represents a response model for authentication.
/// </summary>
///<remarks> Grupo 1: Carga sin estres </remarks>
public class AuthenticateResponse
{
    /// <summary>
    /// Gets or sets the identifier of the authenticated entity.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the email address of the authenticated entity.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Gets or sets the password of the authenticated entity.
    /// </summary>
    public string Password { get; set; }

}