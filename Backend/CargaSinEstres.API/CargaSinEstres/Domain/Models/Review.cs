namespace CargaSinEstres.API.CargaSinEstres.Domain.Models;

/// <summary>
/// Represents a review entity with properties such as identifier, rating, comment, and a foreign key relationship with a company.
/// </summary>
///<remarks> Grupo 1: Carga sin estres </remarks>
public class Review{
    /// <summary>
    /// Gets or sets the unique identifier for the review.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the rating assigned to the review.
    /// </summary>
    public int Rating { get; set; }

    /// <summary>
    /// Gets or sets the comment associated with the review.
    /// </summary>
    public string Comment { get; set; }
    
    /// <summary>
    /// Gets or sets the foreign key referencing the associated company.
    /// </summary>
    public int CompanyId { get; set; }
    
    /// <summary>
    /// Gets or sets the company associated with the review.
    /// </summary>
    public Security.Domain.Models.Company Company { get; set; }
    
}