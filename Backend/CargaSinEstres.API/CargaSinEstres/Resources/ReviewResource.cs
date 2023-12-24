
using CargaSinEstres.API.Security.Resources;

namespace CargaSinEstres.API.CargaSinEstres.Resources;

/// <summary>
/// Represents a resource for reviews.
/// </summary>
/// <remarks> Group 1: Carga sin estres </remarks>
public class ReviewResource
{
    /// <summary>
    /// Gets or sets the identifier of the review.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the rating given in the review.
    /// </summary>
    public int Rating { get; set; }

    /// <summary>
    /// Gets or sets the text comment in the review.
    /// </summary>
    public string Comment { get; set; }
    
    
    
    //public CompanyResource Company { get; set; }
}