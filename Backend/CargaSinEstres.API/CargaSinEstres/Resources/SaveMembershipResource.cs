using System.ComponentModel.DataAnnotations;

namespace CargaSinEstres.API.CargaSinEstres.Resources;

/// <summary>
/// Represents a resource for saving a membership.
/// </summary>
///<remarks> Grupo 1: Carga sin estres </remarks>
public class SaveMembershipResource
{

    /// <summary>
    /// Gets or sets the direction for the membership. The comment must have a minimum length of 10 characters.
    /// </summary>
    [Required]
    [MaxLength(50)]
    public string NombreEmpresa { get; set; }
    
    /// <summary>
    /// Gets or sets the Ruc for the membership. This property is required.
    /// </summary>
    [Required]
    public int Ruc { get; set; }
    
    /// <summary>
    /// Gets or sets the direction for the membership. The comment must have a minimum length of 10 characters.
    /// </summary>
    [Required]
    [MaxLength(100)]
    public string Direction { get; set; }
    
    /// <summary>
    /// Gets or sets the TipoMembresia for the membership. This property is required.
    /// </summary>
    [Required]
    [MaxLength(10)]
    public string TipoMembresia { get; set; }
    
    /// <summary>
    /// Gets or sets the TipoTarjeta for the membership. This property is required.
    /// </summary>
    [Required]
    [MaxLength(10)]
    public string TipoTarjeta { get; set; }
    
    /// <summary>
    /// Gets or sets the IdCompany for the membership. This property is required.
    /// </summary>
    [Required]
    public int IdCompany { get; set; }
}