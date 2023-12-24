using System.Globalization;

namespace CargaSinEstres.API.Security.Exceptions;

/// <summary>
/// Represents an exception specific to the Carga Sin Estres API in the Security domain.
/// </summary>
///<remarks> Grupo 1: Carga sin estres </remarks>
public class AppException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AppException"/> class.
    /// </summary>
    public AppException() : base() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="AppException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public AppException(string message) : base(message) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="AppException"/> class with a formatted error message.
    /// </summary>
    /// <param name="message">The format string of the error message.</param>
    /// <param name="args">An array of objects to format.</param>
    public AppException(string message, params object[] args)
        : base(string.Format(CultureInfo.CurrentCulture, message, args))
    {
    }
}