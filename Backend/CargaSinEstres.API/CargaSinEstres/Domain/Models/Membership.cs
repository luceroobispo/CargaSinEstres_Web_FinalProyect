namespace CargaSinEstres.API.CargaSinEstres.Domain.Models;
/// <summary>
/// Represents a membership entity with properties such as identifier, company name, RUC, and a foreign key relationship with a company.
/// </summary>
///<remarks> Grupo 1: Carga sin estres </remarks>
public class Membership
{
    /// <summary>
    /// Gets or sets the unique identifier for the comment.
    /// </summary>   
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the text content of the NombreEmpresa .
    /// </summary>
    public string NombreEmpresa { get; set; }

    /// <summary>
    /// Gets or sets the ruc assigned to the membership
    /// </summary>    
    public int Ruc { get; set; }

    /// <summary>
    /// Gets or sets the direction associated with the membership.
    /// </summary>
    public string Direction { get; set; }

    /// <summary>
    /// Gets or sets the tipoMembresia associated with the membership.
    /// </summary>
    public string TipoMembresia { get; set; }
    
    /// <summary>
    /// Gets or sets the tipoTarjeta associated with the membership.
    /// </summary>
    public string TipoTarjeta { get; set; }
    
    /// <summary>
    /// Gets or sets the IdCompany associated with the membership.
    /// </summary>
    public int IdCompany { get; set; }
}