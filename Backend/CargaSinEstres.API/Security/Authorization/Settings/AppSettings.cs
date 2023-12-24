namespace CargaSinEstres.API.Security.Authorization.Settings;

/// <summary>
/// Class containing the application configuration.
/// </summary>
///<remarks> Grupo 1: Carga sin estres </remarks>
public class AppSettings
{
    /// <summary>
    /// Gets or sets the secret key used to sign and verify JWT tokens.
    /// </summary>
    public string Secret { get; set; }
}