using CargaSinEstres.API.Security.Authorization.Handlers.Interfaces;
using CargaSinEstres.API.Security.Authorization.Settings;
using CargaSinEstres.API.Security.Domain.Services;
using Microsoft.Extensions.Options;

namespace CargaSinEstres.API.Security.Authorization.Middleware;
/// <summary>
/// Middleware for processing JWT (JSON Web Token) during HTTP requests.
/// </summary>
///<remarks> Grupo 1: Carga sin estres </remarks>
public class JwtMiddleware
{
    private readonly RequestDelegate _next;
    private readonly AppSettings _appSettings;

    /// <summary>
    /// Initializes a new instance of the <see cref="JwtMiddleware"/> class.
    /// </summary>
    /// <param name="next">The next middleware in the pipeline.</param>
    /// <param name="appSettings">Application settings.</param>
    public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
    {
        _next = next;
        _appSettings = appSettings.Value;;
    }

    /// <summary>
    /// Invokes the middleware to process JWT during HTTP requests.
    /// </summary>
    /// <param name="context">The HTTP context.</param>
    /// <param name="companyService">The service for company-related operations.</param>
    /// <param name="handler">The JWT handler.</param>
    /// <param name="clientService">The service for client-related operations.</param>
    /// <returns>A task representing the execution of the middleware.</returns>
    public async Task Invoke(HttpContext context, ICompanyService companyService, IJwtHandler handler, IClientService clientService)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split("").Last();
        var companyId = handler.ValidateToken(token);
        var clientId = handler.ValidateToken(token);
        if (companyId != null && clientId != null)
        { 
            // attach user to context on successful jwt validation
            context.Items["Company"] = await companyService.GetByIdAsync(companyId.Value);
            context.Items["Client"] = await clientService.GetByIdClientAsync(clientId.Value);
        }
        await _next(context);
    }
}