using CargaSinEstres.API.Security.Domain.Models;

namespace CargaSinEstres.API.Security.Authorization.Handlers.Interfaces;

/// <summary>
/// Interface for handling the generation and validation of JWT tokens.
/// </summary>
///<remarks> Grupo 1: Carga sin estres </remarks>
public interface IJwtHandler
{
/// <summary>
    /// Generates a JWT token for the specified company.
    /// </summary>
    /// <param name="company">The company for which the token will be generated.</param>
    /// <returns>The generated JWT token.</returns>
    public string GenerateToken(Company company);
    /// <summary>
    /// Generates a JWT token for the specified client.
    /// </summary>
    /// <param name="client">The client for which the token will be generated.</param>
    /// <returns>The generated JWT token.</returns>
    public string GenerateToken(Client client);
    /// <summary>
    /// Validates a JWT token and returns the user identifier if valid.
    /// </summary>
    /// <param name="token">The JWT token to validate.</param>
    /// <returns>The user identifier if the token is valid; otherwise, null.</returns>
    public int? ValidateToken(string token);
}