namespace CargaSinEstres.API.Security.Domain.Models;

/// <summary>
/// Model for the Client entity.
/// </summary>
///<remarks> Grupo 1: Carga sin estres </remarks>
public class Client{
    /// <summary>
    /// Gets or sets the unique identifier for the client.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the first name of the client.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the last name (paternal) of the client.
    /// </summary>
    public string ApellidoPaterno { get; set; }

    /// <summary>
    /// Gets or sets the last name (maternal) of the client.
     /// </summary>
    public string ApellidoMaterno { get; set; }

    /// <summary>
    /// Gets or sets the client's mobile phone number.
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
    
    /// <summary>
    /// Gets or sets the user type of the company.
    /// </summary>
    public string UserType { get; set; }

}