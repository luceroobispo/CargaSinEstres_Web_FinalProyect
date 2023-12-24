using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CargaSinEstres.API.Security.Authorization.Handlers.Interfaces;
using CargaSinEstres.API.Security.Authorization.Settings;
using CargaSinEstres.API.Security.Domain.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CargaSinEstres.API.Security.Authorization.Handlers.Implementations;

/// <summary>
/// Implementation of the JWT handler for generating and validating tokens.
/// </summary>
///<remarks> Grupo 1: Carga sin estres </remarks>
public class JwtHandler: IJwtHandler
{
    private readonly AppSettings _appSettings;
    private IJwtHandler _jwtHandlerImplementation;

    /// <summary>
    /// Initializes a new instance of the <see cref="JwtHandler"/> class.
    /// </summary>
    /// <param name="appSettings">The application settings.</param>
    public JwtHandler(IOptions<AppSettings> appSettings)
    {
        _appSettings = appSettings.Value;
    }
    
    /// <inheritdoc/>
    public string GenerateToken(Company company)
    {
        // Generate Token for a valid period of 7 days
        var tokenHandler = new JwtSecurityTokenHandler();
        Console.WriteLine($"token handler: {tokenHandler.TokenType}");
        var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        Console.WriteLine($"Secret Key: {key}");
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Sid, company.Id.ToString()),
                new Claim(ClaimTypes.Name, company.Email)
            }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        Console.WriteLine($"token: {token.Id}, {token.Issuer},{token.SecurityKey?.ToString()}");
        return tokenHandler.WriteToken(token);
    }

    /// <inheritdoc/>
    public string GenerateToken(Client client)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public int? ValidateToken(string token)
    {
        if (string.IsNullOrEmpty(token))
            return null;

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

        // Execute Token validation

        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                // Expiration with no delay
                ClockSkew = TimeSpan.Zero
            }, out var validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            var companyId = int.Parse(jwtToken.Claims.First(
                claim => claim.Type == ClaimTypes.Sid).Value);

            return companyId;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }
}