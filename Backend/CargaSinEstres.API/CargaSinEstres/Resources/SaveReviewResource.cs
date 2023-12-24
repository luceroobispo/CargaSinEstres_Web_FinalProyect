using System.ComponentModel.DataAnnotations;

namespace CargaSinEstres.API.CargaSinEstres.Resources;

/// <summary>
/// Represents a resource for saving a review.
/// </summary>
///<remarks> Grupo 1: Carga sin estres </remarks>
public class SaveReviewResource
{
    /// <summary>
    /// Gets or sets the rating for the review. This property is required.
    /// </summary>
    [Required]
    public int Rating { get; set; }

    /// <summary>
    /// Gets or sets the comment for the review. The comment must have a minimum length of 10 characters.
    /// </summary>
    [MinLength(10)]
    public string Comment { get; set; }

}