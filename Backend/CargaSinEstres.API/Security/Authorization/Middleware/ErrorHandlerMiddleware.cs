using System.Net;
using System.Text.Json;
using CargaSinEstres.API.Security.Exceptions;

namespace CargaSinEstres.API.Security.Authorization.Middleware;
/// <summary>
/// Middleware for handling errors and providing standardized error responses.
/// </summary>
///<remarks> Grupo 1: Carga sin estres </remarks>
public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;

    /// <summary>
    /// Initializes a new instance of the <see cref="ErrorHandlerMiddleware"/> class.
    /// </summary>
    /// <param name="next">The next middleware in the pipeline.</param>
    public ErrorHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    /// <summary>
    /// Invokes the middleware to handle errors and provide standardized error responses.
    /// </summary>
    /// <param name="context">The HTTP context.</param>
    /// <returns>A task representing the execution of the middleware.</returns>
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception error)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            switch(error)
            {
                case AppException e: 
                    // custom application error
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                case KeyNotFoundException e: 
                    // not found error
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                default: 
                    // unhandled error
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }
            var result = JsonSerializer.Serialize(new { message = error?.Message });
            await response.WriteAsync(result);
        }
    }
}